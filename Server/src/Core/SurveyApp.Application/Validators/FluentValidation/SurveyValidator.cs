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
    public class SurveyValidator : AbstractValidator<Survey>
    {
        private readonly IUserRepository _userRepository;
        public SurveyValidator( IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(p => p.Title).NotEmpty();
            RuleFor(p => p.CreatedById).NotEmpty().Must(IsUserExist);
        }
        private bool IsUserExist(Guid userId)
        {
            var result = _userRepository.IsExist(userId).GetAwaiter().GetResult();
            return result;
        }

    }
}
