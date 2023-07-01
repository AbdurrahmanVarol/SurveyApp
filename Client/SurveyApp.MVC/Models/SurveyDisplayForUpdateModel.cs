namespace SurveyApp.MVC.Models
{
    public class SurveyDisplayForUpdateModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<QuestionDisplayForUpdateModel> Questions { get; set; } = new List<QuestionDisplayForUpdateModel>();
    }
}
