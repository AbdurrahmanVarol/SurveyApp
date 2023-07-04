namespace SurveyApp.MVC.Models
{
    public class UpdateQuestionModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int QuestionTypeId { get; set; }
        public IEnumerable<UpdateOptionModel> Options { get; set; }
    }
}
