namespace SurveyApp.MVC.Models
{
    public class UpdateSurveyModel
    {
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<UpdateQuestionModel> Questions { get; set; }
    }
}
