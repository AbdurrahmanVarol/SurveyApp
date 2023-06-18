using AutoMapper;
using SurveyApp.Application.Dtos.Requests;
using SurveyApp.Application.Dtos.Responses;
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
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public SurveyService(ISurveyRepository surveyRepository, IMapper mapper, IQuestionRepository questionRepository)
        {
            _surveyRepository = surveyRepository;
            _mapper = mapper;
            _questionRepository = questionRepository;
        }

        public async Task<int> AddAsync(CreateSurveyRequest request)
        {
          var survey = _mapper.Map<Survey>(request);
            await _surveyRepository.AddAsync(survey);
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
