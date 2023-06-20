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
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<Answer> _validator;

        public AnswerService(IAnswerRepository answerRepository, IMapper mapper, IValidator<Answer> validator)
        {
            _answerRepository = answerRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<int> AddAsync(CreateAnswerRequest request)
        {
            //TODO:Validasyon ekle
            var answer = _mapper.Map<Answer>(request);

            _validator.ValidateAndThrowArgumentException(answer);

            await _answerRepository.AddAsync(answer);
            return answer.Id;
        }

        public async Task AddRangeAsync(IEnumerable<CreateAnswerRequest> request)
        {
            foreach (var answer in request)
            {
                await AddAsync(answer);
            }
        }

        public async Task<AnswerResultResponse> GetAnswerResultByQuestionIdAsync(int questionId)
        {
            //TODO: Mapping ekle
            //TODO: Debug ile kontol et
            var result = await _answerRepository.GetAnswerResultByQuestionIdAsync(questionId);
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AnswerResultResponse>> GetAnswerResultsBySurveyIdAsync(int surveyId)
        {
            var result = _answerRepository.GetAnswerResultByQuestionIdAsync(surveyId);
            throw new NotImplementedException();
        }
    }
}
