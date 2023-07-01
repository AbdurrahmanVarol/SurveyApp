using SurveyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Domain.ComplexTypes
{
    public class AnswerResult
    {
        public int AnswerCount { get; set; }
        public Option Option { get; set; }
    }
}
