using FluentValidation;
using SurveyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Validators.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p=>p.FirstName).NotEmpty();
            RuleFor(p=>p.LastName).NotEmpty();
            RuleFor(p=>p.Email).NotEmpty().EmailAddress();
            RuleFor(p=>p.UserName).NotEmpty();
            RuleFor(p=>p.PasswordHash).NotEmpty();
            RuleFor(p=>p.PasswordSalt).NotEmpty();
            RuleFor(p=>p.RefreshToken).NotEmpty();
        }
    }
}
