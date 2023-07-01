namespace SurveyApp.MVC.Models
{
    public class CreateQuestionModel
    {       
        public string Text { get; set; }
        public int QuestionTypeId { get; set; }
        public IEnumerable<string> Options { get; set; }
    }
}
