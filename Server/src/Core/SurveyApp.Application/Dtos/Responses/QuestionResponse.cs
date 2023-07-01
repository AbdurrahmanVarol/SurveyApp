using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Dtos.Responses
{
    public class QuestionResponse
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public QuestionTypeResponse QuestionType { get; set; }
        public IEnumerable<OptionResponse> Options { get; set; }
    }
}
