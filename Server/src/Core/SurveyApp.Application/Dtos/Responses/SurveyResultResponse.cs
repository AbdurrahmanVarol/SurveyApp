using SurveyApp.Domain.ComplexTypes;
using SurveyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Dtos.Responses
{
    public class SurveyResultResponse
    {
        public SurveyDisplayResponse Survey { get; set; }
        public IEnumerable<QuestionResultResponse> Questions { get; set; }
    }
}
