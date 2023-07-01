using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Dtos.Requests
{
    public class CreateSurveyRequest
    {
        public string Title { get; set; }
        public Guid? CreatedById { get; set; }
        public List<CreateQuestionRequest> Questions { get; set; } = new List<CreateQuestionRequest>();
    }
}
