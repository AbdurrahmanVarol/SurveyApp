using SurveyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Domain.ComplexTypes
{
    public class SurveyResult
    {
        public Survey Survey{ get; set; }

        public IEnumerable<QuestionResult> Questions { get; set; }
    }
}
