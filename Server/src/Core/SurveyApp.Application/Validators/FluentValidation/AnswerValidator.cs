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
        private readonly IUserRepository _userRepository;
        public AnswerValidator(IOptionRepository optionRepository, IUserRepository userRepository)
        {
            _optionRepository = optionRepository;

            RuleFor(p => p.OptionId).Must(IsOptionExist).WithMessage("Option tanımlı değil");
            When(p => p.UserId != null, () =>
            {
                RuleFor(p => p.UserId).NotEmpty().Must(IsUserExist);
            });
            _userRepository = userRepository;
        }
        private bool IsOptionExist(int optionId) 
        {
            var result = _optionRepository.IsExist(optionId).GetAwaiter().GetResult();
            return result;
        }
        private bool IsUserExist(Guid? userId)
        {
            var result = _userRepository.IsExist(userId).GetAwaiter().GetResult();
            return result;
        }
    }
}
