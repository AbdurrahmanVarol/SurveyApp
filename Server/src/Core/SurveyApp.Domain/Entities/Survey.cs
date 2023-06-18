using SurveyApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Domain.Entities
{
    public class Survey : BaseEntity
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required DateTime CreatedAt { get; set; }

        public required Guid CreatedById { get; set; }
        public User CreatedBy { get; set; }

        public ICollection<Question> Questions { get; set; } = new List<Question>();
    }
}
