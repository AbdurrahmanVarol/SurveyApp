using AutoMapper;
using FluentValidation;
using SurveyApp.Application.Dtos.Requests;
using SurveyApp.Application.Dtos.Responses;
using SurveyApp.Application.Extensions.ValidationExtensions;
using SurveyApp.Application.Interfaces.Repositories;
using SurveyApp.Application.Interfaces.Services;
using SurveyApp.Domain.Entities;
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
            //TODO:Mapping düzgün çalışıyor mu?
            var question = _mapper.Map<Question>(request);

            _validator.ValidateAndThrowArgumentException(question);

            await _questionRepository.AddAsync(question);
            return question.Id;
        }

        public async Task<int> AddRangeAsync(IEnumerable<CreateQuestionRequest> request, Guid surveyId)
        {
            foreach (var question in request)
            {
                question.SurveyId = surveyId;
                var questionId = await AddAsync(question);

                if (question.QuestionTypeId == 1 || question.QuestionTypeId == 2)
                {
                    await _optionService.AddRangeAsync(question.Options, questionId);
                }
            }
            return 0;
        }

        public async Task<QuestionResponse> GetQuestionByIdAsync(int id)
        {
            var question = await _questionRepository.GetAsync(p => p.Id == id);
            return _mapper.Map<QuestionResponse>(question);
        }

        public async Task<IEnumerable<QuestionResponse>> GetQuestionsBySurveyIdAsync(Guid surveyId)
        {
            //TODO:Mapping düzgün çalışıyor mu?
            var questions = await _questionRepository.GetAllAsync(p => p.SurveyId == surveyId);
            return _mapper.Map<IEnumerable<QuestionResponse>>(questions);
        }
    }
}
