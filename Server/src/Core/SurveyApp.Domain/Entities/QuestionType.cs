using SurveyApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Domain.Entities
{
    public class QuestionType : BaseEntity
    {
        public required int Id { get; set; }
        public required string Name { get; set; }

        public ICollection<Question> Questions { get; set;}
    }
}
