namespace SurveyApp.MVC.Models
{
    public class QuestionModel
    {
        public string Text { get; set; }
        public int QuestionTypeId { get; set; }
        public IEnumerable<string> Options { get; set; }
    }
}
