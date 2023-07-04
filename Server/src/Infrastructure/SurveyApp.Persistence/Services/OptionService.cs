using AutoMapper;
using Azure.Core;
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
    public class OptionService : IOptionService
    {
        private readonly IOptionRepository _optionRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<Option> _validator;

        public OptionService(IOptionRepository optionRepository, IMapper mapper, IValidator<Option> validator)
        {
            _optionRepository = optionRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<int> AddAsync(CreateOptionRequest request)
        {
            var option = _mapper.Map<Option>(request);

            _validator.ValidateAndThrowArgumentException(option);

            await _optionRepository.AddAsync(option);
            return option.Id;
        }

        public async Task AddRangeAsync(IEnumerable<string> request, int questionId)
        {
            foreach (var option in request)
            {

                await AddAsync(new CreateOptionRequest
                {
                    Text = option,
                    QuestionId = questionId
                });
            }
        }

        public async Task DeleteAsync(int optionId)
        {
            var option = await _optionRepository.GetAsync(p => p.Id == optionId) ?? throw new ArgumentException("");

            await _optionRepository.DeleteAsync(option);
        }

        public async Task DeleteRangeAsync(IEnumerable<int> removedOptions)
        {
            foreach (var optionId in removedOptions)
            {
                await DeleteAsync(optionId);
            }
        }
    }
}
