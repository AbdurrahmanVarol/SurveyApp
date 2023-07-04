using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Dtos.Requests
{
    public class UpdateQuestionRequest
    {
        public int? Id { get; set; }
        public string Text { get; set; }
        public int QuestionTypeId { get; set; }
        public Guid? SurveyId { get; set; }
        public List<UpdateOptionRequest> Options { get; set; } = new List<UpdateOptionRequest>();
    }
}
