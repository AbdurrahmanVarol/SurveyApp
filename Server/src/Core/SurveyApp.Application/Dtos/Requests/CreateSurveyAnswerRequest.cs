using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Dtos.Requests
{
    public class CreateSurveyAnswerRequest
    {
        public IEnumerable<CreateAnswerRequest> OptionalAnswers { get; set; } = Enumerable.Empty<CreateAnswerRequest>();
        public IEnumerable<CreateTextAnswerRequest> TextAnswers { get; set; } = Enumerable.Empty<CreateTextAnswerRequest>();
    }
}
