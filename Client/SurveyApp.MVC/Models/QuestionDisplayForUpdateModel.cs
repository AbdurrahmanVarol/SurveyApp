using System.Text.Json;

namespace SurveyApp.MVC.Models
{
    public class QuestionDisplayForUpdateModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int QuestionTypeId { get; set; }
        public List<OptionModel> Options { get; set; } = new List<OptionModel>();
    }
}
