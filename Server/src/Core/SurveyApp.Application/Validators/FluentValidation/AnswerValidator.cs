using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SurveyApp.Application.Interfaces.Repositories;
using SurveyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Validators.FluentValidation
{
    public class AnswerValidator : AbstractValidator<Answer>
    {
        private readonly IOptionRepository _optionRepository;
        public AnswerValidator(IOptionRepository optionRepository)
        {
            _optionRepository = optionRepository;

            RuleFor(p => p.OptionId).Must(IsOptionExist).WithMessage("Option tanımlı değil");
        }
        private bool IsOptionExist(int optionId) 
        {
            var result = _optionRepository.IsExist(optionId).GetAwaiter().GetResult();
            return result;
        }
    }
}
