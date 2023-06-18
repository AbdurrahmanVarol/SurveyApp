using SurveyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Dtos.Requests
{
    public class CreateOptionRequest
    {
        public required string Text { get; set; }
        public int QuestionId { get; set; }
    }
}
