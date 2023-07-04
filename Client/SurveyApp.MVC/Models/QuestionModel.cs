using System.Text.Json;

namespace SurveyApp.MVC.Models
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public QuestionTypeModel QuestionType { get; set; }
        public List<OptionModel> Options { get; set; } = new List<OptionModel>();
    }
}
