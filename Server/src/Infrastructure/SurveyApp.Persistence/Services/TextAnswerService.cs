using AutoMapper;
using FluentValidation;
using SurveyApp.Application.Dtos.Requests;
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
    public class TextAnswerService : ITextAnswerService
    {
        private readonly ITextAnswerRepository _textAnswerRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<TextAnswer> _validator;

        public TextAnswerService(ITextAnswerRepository textAnswerRepository, IMapper mapper, IValidator<TextAnswer> validator)
        {
            _textAnswerRepository = textAnswerRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<int> AddAsync(CreateTextAnswerRequest request)
        {
            var answer = _mapper.Map<TextAnswer>(request);

            _validator.ValidateAndThrowValidationException(answer);

            await _textAnswerRepository.AddAsync(answer);
            return answer.Id;
        }

        public async Task AddRangeAsync(IEnumerable<CreateTextAnswerRequest> request)
        {
            foreach (var answer in request) 
            {
                await AddAsync(answer);
            }
        }
    }
}
