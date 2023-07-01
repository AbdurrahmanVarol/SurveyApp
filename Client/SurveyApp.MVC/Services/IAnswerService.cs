using SurveyApp.MVC.Models;

namespace SurveyApp.MVC.Services
{
    public interface IAnswerService
    {
        Task CreateAnswers(AnswerModel answer);
    }
}
