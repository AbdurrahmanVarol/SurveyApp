using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Dtos.Requests
{
    public class CreateTextAnswerRequest
    {
        public int QuestionId { get; set; }
        public int QuestionTypeId { get; set; }
        public string Value { get; set; }
    }
}
