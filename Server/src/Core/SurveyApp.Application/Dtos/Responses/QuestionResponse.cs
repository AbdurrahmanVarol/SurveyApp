using SurveyApp.Domain.Entities;
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

        public int QuestionTypeId { get; set; }
        public string QuestionType { get; set; }

        public ICollection<OptionResponse> Options { get; set; } = new List<OptionResponse>();
    }
}
