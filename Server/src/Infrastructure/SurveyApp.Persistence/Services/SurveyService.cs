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
    public class SurveyService : ISurveyService
    {
        private readonly ISurveyRepository _surveyRepository;
        private readonly IQuestionService _questionService;
        private readonly IMapper _mapper;
        private readonly IValidator<Survey> _validator;

        public SurveyService(ISurveyRepository surveyRepository, IQuestionService questionService, IMapper mapper, IValidator<Survey> validator)
        {
            _surveyRepository = surveyRepository;
            _questionService = questionService;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<int> AddAsync(CreateSurveyRequest request)
        {
            var survey = _mapper.Map<Survey>(request);
            //var survey = new Survey
            //{
            //    CreatedAt = DateTime.Now,
            //    CreatedById = request.CreatedById,
            //    Title = request.Title,
            //};

            _validator.ValidateAndThrowArgumentException(survey);

            await _surveyRepository.AddAsync(survey);

            await _questionService.AddRangeAsync(request.Questions,survey.Id);

            return survey.Id;
        }

        public async Task<SurveyResponse> GetSurveyByIdAsync(int id)
        {
            var survey = await _surveyRepository.GetAsync(p => p.Id == id);

            return _mapper.Map<SurveyResponse>(survey);
        }

        public async Task<IEnumerable<SurveyDisplayResponse>> GetSurveysAsync()
        {
            var surveys = await _surveyRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SurveyDisplayResponse>>(surveys);
        }
    }
}
