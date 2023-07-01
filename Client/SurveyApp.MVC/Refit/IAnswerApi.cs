using Refit;
using SurveyApp.MVC.Models;

namespace SurveyApp.MVC.Refit
{
    public interface IAnswerApi
    {
        [Post("/answers/CreateOptionalAnswers")]
        Task CreateOptionalAnswers(IEnumerable<OptionalAnswerModel> optionalAnswers);  
        
        [Post("/answers/CreateTextAnswers")]
        Task CreateTextAnswers(IEnumerable<TextAnswerModel> optionalAnswers);
    }
}
