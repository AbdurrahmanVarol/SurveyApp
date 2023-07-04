using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Dtos.Requests
{
    public class UpdateSurveyRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid? CreatedById { get; set; }
        public List<UpdateQuestionRequest> Questions { get; set; } = new List<UpdateQuestionRequest>();
    }
}
