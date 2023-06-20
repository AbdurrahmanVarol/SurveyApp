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
    public class QuestionValidator : AbstractValidator<Question>
    {
        private readonly DbContext _context;

        public QuestionValidator(DbContext context)
        {
            _context = context;
            RuleFor(p => p.SurveyId).NotEmpty().Must(IsSurveyExist);
            RuleFor(p => p.QuestionTypeId).NotEmpty().Must(IsQuestionTypeExist);
            RuleFor(p => p.Text).NotEmpty();
        }

        private bool IsQuestionTypeExist(int typeId)
        {
            var result = _context.Set<QuestionType>().Any(p => p.Id == typeId);
            return result;
        }

        private bool IsSurveyExist(int questionId)
        {
            var result = _context.Set<Question>().Any(p => p.Id == questionId);
            return result;
        }
    }
}
