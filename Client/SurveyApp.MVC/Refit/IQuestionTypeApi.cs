using Refit;
using SurveyApp.MVC.Models;

namespace SurveyApp.MVC.Refit
{
    public interface IQuestionTypeApi
    {
        [Get("/questionTypes")]
        Task<IEnumerable<QuestionTypeModel>> GetQuestionTypes();
    }
}
