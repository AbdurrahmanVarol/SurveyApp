namespace SurveyApp.MVC.Models
{
    public class CreateSurveyModel
    {
        public string Title { get; set; }        
        public DateTime CreatedAt { get; set; }
        public IEnumerable<CreateQuestionModel> Questions { get; set; }
    }
}
