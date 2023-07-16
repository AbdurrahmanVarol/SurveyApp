using AutoMapper;
using Azure.Core;
using FluentValidation;
using SurveyApp.Application.Dtos.Requests;
using SurveyApp.Application.Dtos.Responses;
using SurveyApp.Application.Extensions.ValidationExtensions;
using SurveyApp.Application.Interfaces.Repositories;
using SurveyApp.Application.Interfaces.Services;
using SurveyApp.Domain.Entities;
using SurveyApp.Persistence.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Persistence.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IOptionService _optionService;
        private readonly IMapper _mapper;
        private readonly IValidator<Question> _validator;

        public QuestionService(IQuestionRepository questionRepository, IOptionService optionService, IMapper mapper, IValidator<Question> validator)
        {
            _questionRepository = questionRepository;
            _optionService = optionService;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<int> AddAsync(CreateQuestionRequest request)
        {
            var question = _mapper.Map<Question>(request);

            _validator.ValidateAndThrowValidationException(question);

            await _questionRepository.AddAsync(question);
            return question.Id;
        }

        public async Task AddRangeAsync(IEnumerable<CreateQuestionRequest> request, Guid surveyId)
        {
            foreach (var question in request)
            {
                question.SurveyId = surveyId;
                var questionId = await AddAsync(question);

                if (question.QuestionTypeId == 1 || question.QuestionTypeId == 2 || question.QuestionTypeId == 3)
                {
                    await _optionService.AddRangeAsync(question.Options, questionId);
                }
            }
        }

        public async Task DeleteAsync(int questionId)
        {
            var question = await _questionRepository.GetAsync(p => p.Id == questionId);
            if (question is null)
            {
                throw new ArgumentNullException(nameof(question));
            }
            await _questionRepository.DeleteAsync(question);

        }

        public async Task DeleteRangeAsync(List<int> removedQuestions)
        {
            foreach (var question in removedQuestions)
            {
                await DeleteAsync(question);
            }
        }

        public async Task<QuestionResponse> GetQuestionByIdAsync(int id)
        {
            var question = await _questionRepository.GetAsync(p => p.Id == id);
            return _mapper.Map<QuestionResponse>(question);
        }

        public async Task<IEnumerable<QuestionResponse>> GetQuestionsBySurveyIdAsync(Guid surveyId)
        {
            var questions = await _questionRepository.GetAllAsync(p => p.SurveyId == surveyId);
            return _mapper.Map<IEnumerable<QuestionResponse>>(questions);
        }

        public async Task UpdateAsync(UpdateQuestionRequest request)
        {
            var question = await _questionRepository.GetAsync(p => p.Id == request.Id) ?? throw new ArgumentNullException(nameof(request));

            question.QuestionTypeId = request.QuestionTypeId;
            question.Text = request.Text;

            _validator.ValidateAndThrowValidationException(question);

            await _questionRepository.UpdateAsync(question);

            if (request.QuestionTypeId == 1 || request.QuestionTypeId == 2)
            {
                var addedOptions = request.Options.Where(p => p.Id == null).Select(p => p.Text).ToList();
                var removedOptions = question.Options.Where(p => !request.Options.Where(p => p.Id != null).Select(s => s.Id).Contains(p.Id)).Select(p => p.Id).ToList();
               
                await _optionService.AddRangeAsync(addedOptions, question.Id);
                await _optionService.DeleteRangeAsync(removedOptions);
            }

        }
        public async Task UpdateRangeAsync(List<UpdateQuestionRequest> questions, Guid surveyId)
        {
            foreach (var questionRequest in questions)
            {
                questionRequest.SurveyId = surveyId;
                await UpdateAsync(questionRequest);
            }
        }
    }
}
