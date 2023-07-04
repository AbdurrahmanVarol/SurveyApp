namespace SurveyApp.MVC.Models
{
    public class SurverResultModel
    {
        public SurveyDisplayModel Survey { get; set; }
        public IEnumerable<QuestionResultModel> Questions { get; set; }
    }
}
