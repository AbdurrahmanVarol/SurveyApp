using FluentValidation;
using Microsoft.EntityFrameworkCore;
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
        private readonly DbContext _dbContext;
        public SurveyValidator(DbContext dbContext)
        {
            _dbContext = dbContext;
            RuleFor(p => p.Title).NotEmpty();
            RuleFor(p=> p.CreatedById).NotEmpty().Must(IsUserExist);
        }
        private bool IsUserExist(Guid userId)
        {
            var result = _dbContext.Set<User>().Any(p => p.Id == userId);
            return result;
        }

    }
}
