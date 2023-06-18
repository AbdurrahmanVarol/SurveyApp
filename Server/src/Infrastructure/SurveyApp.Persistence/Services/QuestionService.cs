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
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public QuestionService(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(CreateQuestionRequest request)
        {
            //TODO:Mapping düzgün çalışıyor mu?
            var question = _mapper.Map<Question>(request);
            await _questionRepository.AddAsync(question);
            return question.Id;
        }

        public async Task<IEnumerable<QuestionDisplayResponse>> GetQuestionsBySurveyId(int surveyId)
        {
            //TODO:Mapping düzgün çalışıyor mu?
            var questions = await _questionRepository.GetAllAsync(p=>p.SurveyId == surveyId);
            return _mapper.Map<IEnumerable<QuestionDisplayResponse>>(questions);
        }
    }
}
