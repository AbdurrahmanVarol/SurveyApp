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
    public class OptionValidator : AbstractValidator<Option>
    {
        private readonly DbContext _context;
        public OptionValidator(DbContext context)
        {
            _context = context;

            RuleFor(p => p.QuestionId).NotEmpty().Must(IsQuesyionExist);
            RuleFor(p => p.Text).NotEmpty();
        }

        private bool IsQuesyionExist(int questionId)
        {
            var result = _context.Set<Question>().Any(p => p.Id == questionId);
            return result;
        }
    }
}
