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
            using var transaction = await _transaction.BeginTransactionAsync();

            try
            {
                var survey = _mapper.Map<Survey>(request);

                survey.CreatedAt = DateTime.Now;
                _validator.ValidateAndThrowValidationException(survey);

                await _surveyRepository.AddAsync(survey);

                await _questionService.AddRangeAsync(request.Questions, survey.Id);
                await transaction.CommitAsync();
                return survey.Id;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
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
            using var transaction = await _transaction.BeginTransactionAsync();
            try
            {
                var survey = await _surveyRepository.GetAsync(p => p.Id == updateSurveyRequest.Id) ?? throw new ArgumentNullException(nameof(updateSurveyRequest));

                survey.Title = updateSurveyRequest.Title;

                _validator.ValidateAndThrowValidationException(survey);

                await _surveyRepository.UpdateAsync(survey);


                var addedQuestions = updateSurveyRequest.Questions.Where(p => p.Id == null || p.Id == default(int)).Select(p => new CreateQuestionRequest
                {
                    Text = p.Text,
                    QuestionTypeId = p.QuestionTypeId,
                    Options = p.Options.Select(p => p.Text).ToList()
                }).ToList();
                var removedQuestions = survey.Questions.Where(p => !updateSurveyRequest.Questions.Where(p => p.Id != null || p.Id != default(int)).Select(s => s.Id).Contains(p.Id)).Select(p => p.Id).ToList();
                updateSurveyRequest.Questions.RemoveAll(u => removedQuestions.Contains((int)u.Id) || u.Id == default(int) || u.Id == null);

                await _questionService.AddRangeAsync(addedQuestions, survey.Id);
                await _questionService.DeleteRangeAsync(removedQuestions);
                await _questionService.UpdateRangeAsync(updateSurveyRequest.Questions, survey.Id);

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
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
