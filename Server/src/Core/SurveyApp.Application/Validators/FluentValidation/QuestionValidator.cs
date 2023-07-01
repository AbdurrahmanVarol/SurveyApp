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
    public class QuestionValidator : AbstractValidator<Question>
    {
        private readonly ISurveyRepository _surveyRepository;
        private readonly IQuestionTypeRepository _questionTypeRepository;

        public QuestionValidator(ISurveyRepository surveyRepository, IQuestionTypeRepository questionTypeRepository)
        {
            _surveyRepository = surveyRepository;
            _questionTypeRepository = questionTypeRepository;
         
            RuleFor(p => p.SurveyId).NotEmpty().Must(IsSurveyExist);
            RuleFor(p => p.QuestionTypeId).NotEmpty().Must(IsQuestionTypeExist);
            RuleFor(p => p.Text).NotEmpty();
        }

        private bool IsQuestionTypeExist(int typeId)
        {
            var result = _questionTypeRepository.IsExist(typeId).GetAwaiter().GetResult();
            return result;
        }

        private bool IsSurveyExist(Guid surveyId)
        {
            var result = _surveyRepository.IsExist(surveyId).GetAwaiter().GetResult();
            return result;
        }
    }
}
