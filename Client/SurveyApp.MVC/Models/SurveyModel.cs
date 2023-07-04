namespace SurveyApp.MVC.Models
{
    public class SurveyModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public UserDisplayModel CreatedBy { get; set; }
        public List<QuestionModel> Questions { get; set; } = new List<QuestionModel>();
    }
}
