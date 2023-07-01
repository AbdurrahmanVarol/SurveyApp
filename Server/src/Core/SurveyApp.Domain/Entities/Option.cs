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
        public int Id { get; set; }
        public required string Text { get; set; }

        public int QuestionId { get; set; }
        public Question? Question { get; set; }

        public ICollection<Answer> Answers { get; set; } = new List<Answer>();
    }
}
