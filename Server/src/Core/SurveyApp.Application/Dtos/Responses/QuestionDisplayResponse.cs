using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Dtos.Responses
{
    public class QuestionDisplayResponse
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int QuestionTypeId { get; set; }
        public IEnumerable<OptionResponse> Options { get; set; }
    }
}
