using SurveyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Dtos.Responses
{
    public class SurveyResponse
    {
        public Guid Id { get; set; }
        public  string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public IEnumerable<QuestionResponse> Questions { get; set; }
    }
}
