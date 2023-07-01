namespace SurveyApp.MVC.Models
{
    public class QuestionTypeViewModel
    {
        public int? SelectedType { get; set; }

        public IEnumerable<QuestionTypeModel> QuestionTypes { get; set; }
    }
}
