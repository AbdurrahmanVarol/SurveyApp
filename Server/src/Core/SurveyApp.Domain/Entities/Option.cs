using SurveyApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Domain.Entities
{
    public class Option : BaseEntity
    {
        public required int Id { get; set; }
        public required string Text { get; set; }

        public required int QuestionId { get; set; }
        public required Question Question { get; set; }
    }
}
