namespace SurveyApp.MVC.Models
{
    public class SurveyDisplayModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
