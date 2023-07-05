namespace SurveyApp.MVC.Models
{
    public class UpdateSurveyModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedById { get; set; }
        public List<UpdateQuestionModel> Questions { get; set; }
    }
}
