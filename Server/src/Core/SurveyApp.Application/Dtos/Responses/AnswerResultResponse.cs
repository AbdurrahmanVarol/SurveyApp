using SurveyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Dtos.Responses
{
    public class AnswerResultResponse
    {
        public int AnswerCount { get; set; }
        public OptionResponse Option { get; set; }
    }
}
