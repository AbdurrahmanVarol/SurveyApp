using FluentValidation;
using SurveyApp.Application.Interfaces.Repositories;
using SurveyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Validators.FluentValidation
{
    public class TextAnswerValidator : AbstractValidator<TextAnswer>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IUserRepository _userRepository;
        public TextAnswerValidator(IQuestionRepository questionRepository, IUserRepository userRepository)
        {
            _questionRepository = questionRepository;
            _userRepository = userRepository;

            RuleFor(p => p.Value).NotEmpty();
            RuleFor(p => p.QuestionId).NotEmpty().Must(IsQuestionExist);
            When(p => p.UserId != null, () =>
            {
                RuleFor(p => p.UserId).NotEmpty().Must(IsUserExist);
            });
        }
        private bool IsQuestionExist(int questionId)
        {
            var result = _questionRepository.IsExist(questionId).GetAwaiter().GetResult();
            return result;
        }
        private bool IsUserExist(Guid? userId)
        {
            var result = _userRepository.IsExist(userId).GetAwaiter().GetResult();
            return result;
        }
    }
}
