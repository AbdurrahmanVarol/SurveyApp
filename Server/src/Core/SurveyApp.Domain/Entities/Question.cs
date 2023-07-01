using SurveyApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Domain.Entities
{
    public class Question : BaseEntity
    {
        public int Id { get; set; }
        public required string Text { get; set; }

        public required Guid SurveyId { get; set; }
        public Survey? Survey { get; set; }

        public required int QuestionTypeId { get; set; }
        public QuestionType? QuestionType { get; set; }

        public ICollection<Option> Options { get; set; } = new List<Option>();

        public ICollection<TextAnswer> TextAnswers { get; set; } = new List<TextAnswer>();
    }
}
