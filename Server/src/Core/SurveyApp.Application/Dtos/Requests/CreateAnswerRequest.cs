using SurveyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Dtos.Requests
{
    public class CreateAnswerRequest
    {
        public int QuestionId { get; set; }
        public int QuestionTypeId { get; set; }
        public int OptionId { get; set; }
    }
}
