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
    public class AnswerValidator : AbstractValidator<Answer>
    {
        private readonly DbContext _dbContext;
        public AnswerValidator(DbContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(p => p.OptionId).Must(IsOptionExist).WithMessage("Option tanımlı değil");
        }
        private bool IsOptionExist(int optionId) 
        {
            var result = _dbContext.Set<Option>().Any(p=>p.Id == optionId);
            return result;
        }
    }
}
