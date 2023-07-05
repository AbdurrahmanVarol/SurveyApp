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

        public async Task<IEnumerable<AnswerResultResponse>> GetAnswerResultByQuestionIdAsync(int questionId)
        {
         
            var result = await _answerRepository.GetAnswerResultByQuestionIdAsync(questionId);
            return _mapper.Map<IEnumerable<AnswerResultResponse>>(result);
        }

        public async Task<SurveyResultResponse> GetAnswerResultsBySurveyIdAsync(Guid surveyId,Guid userId)
        {
            var result = await _answerRepository.GetAnswerResultsBySurveyIdAsync(surveyId);

            if(result != null && result.Survey.CreatedById != userId)
            {
                throw new ArgumentException($"Ulaşmak istediğiniz anket {result.Survey.CreatedBy.FirstName} {result.Survey.CreatedBy.LastName} kullanıcısına ait değil");
            }

            return _mapper.Map<SurveyResultResponse> (result);
        }
    }
}
