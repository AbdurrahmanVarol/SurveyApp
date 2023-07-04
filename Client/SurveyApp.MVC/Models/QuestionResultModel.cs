namespace SurveyApp.MVC.Models
{
    public class QuestionResultModel
    {
        public QuestionModel Question { get; set; }

        public IEnumerable<AnswerResultModel> Answers { get; set; }
    }
}
