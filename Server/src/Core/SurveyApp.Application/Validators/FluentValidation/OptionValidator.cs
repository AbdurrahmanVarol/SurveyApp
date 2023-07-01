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
    public class OptionValidator : AbstractValidator<Option>
    {
        private readonly IQuestionRepository _questionRepository;
        public OptionValidator(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;

            RuleFor(p => p.QuestionId).NotEmpty().Must(IsQuestionExist);
            RuleFor(p => p.Text).NotEmpty();
        }

        private bool IsQuestionExist(int questionId)
        {
            var result = _questionRepository.IsExist(questionId).GetAwaiter().GetResult();
            return result;
        }
    }
}
