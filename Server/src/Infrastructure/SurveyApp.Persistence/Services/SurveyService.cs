using AutoMapper;
using Azure.Core;
using FluentValidation;
using SurveyApp.Application.Dtos.Requests;
using SurveyApp.Application.Dtos.Responses;
using SurveyApp.Application.Extensions.ValidationExtensions;
using SurveyApp.Application.Interfaces.Repositories;
using SurveyApp.Application.Interfaces.Services;
using SurveyApp.Application.Interfaces.Transaction;
using SurveyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Persistence.Services
{
    public class SurveyService : ISurveyService
    {
        private readonly ISurveyRepository _surveyRepository;
        private readonly IQuestionService _questionService;
        private readonly IMapper _mapper;
        private readonly IValidator<Survey> _validator;
        private readonly IDatabaseTransaction _transaction;

        public SurveyService(ISurveyRepository surveyRepository, IQuestionService questionService, IMapper mapper, IValidator<Survey> validator, IDatabaseTransaction transaction)
        {
            _surveyRepository = surveyRepository;
            _questionService = questionService;
            _mapper = mapper;
            _validator = validator;
            _transaction = transaction;
        }

        public async Task<Guid> AddAsync(CreateSurveyRequest request)
        {
            try
            {
                var survey = _mapper.Map<Survey>(request);

                survey.CreatedAt = DateTime.Now;
                _validator.ValidateAndThrowArgumentException(survey);

                await _surveyRepository.AddAsync(survey);

                await _questionService.AddRangeAsync(request.Questions, survey.Id);
                await _transaction.Commit();
                return survey.Id;
            }
            catch (Exception exception)
            {
                await _transaction.Rollback();
                throw exception;
            }
            finally
            {
                await _transaction.DisposeAsync();
            }
        }

        public async Task DeleteAsync(Guid surveyId)
        {
            var survey = await _surveyRepository.GetAsync(p => p.Id == surveyId);
            if (survey is null)
            {
                throw new ArgumentNullException(nameof(survey));
            }
            await _surveyRepository.DeleteAsync(survey);
        }

        public async Task UpdateAsync(UpdateSurveyRequest updateSurveyRequest)
        {
            try
            {
                var survey = await _surveyRepository.GetAsync(p => p.Id == updateSurveyRequest.Id) ?? throw new ArgumentNullException(nameof(updateSurveyRequest));

                var updatedSurvey = _mapper.Map<Survey>(updateSurveyRequest);

                _validator.ValidateAndThrowArgumentException(updatedSurvey);

                await _surveyRepository.UpdateAsync(survey);

                await _questionService.UpdateRangeAsync(updateSurveyRequest.Questions);

                var addedQuestions = updateSurveyRequest.Questions.Where(p => p.Id == null).Select(p => new CreateQuestionRequest
                {
                    Text = p.Text,
                    QuestionTypeId = p.QuestionTypeId
                });
                var removedQuestions = survey.Questions.Where(p => !updateSurveyRequest.Questions.Where(p => p.Id != null).Select(s => s.Id).Contains(p.Id)).Select(p => p.Id).ToList();
                var UpdatedQuestions = updateSurveyRequest.Questions.RemoveAll(u => removedQuestions.Contains((int)u.Id));
                //TODO:
                await _questionService.AddRangeAsync(addedQuestions, updatedSurvey.Id);
                //await _questionService.UpdateRangeAsync(UpdatedQuestions);
                await _questionService.DeleteRangeAsync(removedQuestions);
            }
            catch (Exception exception)
            {
                await _transaction.Rollback();
                throw exception;
            }
            finally
            {
                await _transaction.DisposeAsync();
            }
        }

        public async Task<SurveyResponse> GetSurveyByIdAsync(Guid id)
        {
            var survey = await _surveyRepository.GetAsync(p => p.Id == id);

            return _mapper.Map<SurveyResponse>(survey);
        }

        public async Task<SurveyDisplayForUpdateResponse> GetSurveyForUpdateByIdAsync(Guid id)
        {
            var survey = await _surveyRepository.GetAsync(p => p.Id == id);

            return _mapper.Map<SurveyDisplayForUpdateResponse>(survey);
        }

        public async Task<IEnumerable<SurveyDisplayResponse>> GetSurveysAsync()
        {
            var surveys = (await _surveyRepository.GetAllAsync()).OrderByDescending(p => p.CreatedAt);
            return _mapper.Map<IEnumerable<SurveyDisplayResponse>>(surveys);
        }

        public async Task<IEnumerable<SurveyDisplayResponse>> GetSurveysByUserIdAsync(Guid userId)
        {
            var surveys = await _surveyRepository.GetAllAsync(p => p.CreatedById == userId);
            return _mapper.Map<IEnumerable<SurveyDisplayResponse>>(surveys);
        }
    }
}
