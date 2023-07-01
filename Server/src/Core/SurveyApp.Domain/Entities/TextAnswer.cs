using SurveyApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Domain.Entities
{
    public class TextAnswer : BaseEntity
    {
        public int Id { get; set; }
        public required string Value { get; set; }

        public int QuestionId { get; set; }
        public Question? Question { get; set; }

        public Guid? UserId { get; set; }
        public User? User { get; set; }
    }
}
