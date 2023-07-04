using Refit;
using SurveyApp.MVC.Models;

namespace SurveyApp.MVC.Refit
{
    public interface IAnswerApi
    {
        [Post("/answers/CreateOptionalAnswers")]
        Task<IApiResponse> CreateOptionalAnswers(IEnumerable<OptionalAnswerModel> optionalAnswers);  
        
        [Post("/answers/CreateTextAnswers")]
        Task<IApiResponse> CreateTextAnswers(IEnumerable<TextAnswerModel> optionalAnswers);
        
        [Post("/answers/CreateSurveyAnswers")]
        Task<IApiResponse> CreateSurveyAnswers(AnswerModel surveyAnswers);

        [Get("/answers/surveyResult/{surveyId}")]
        Task<SurverResultModel> GetSurveyResultById(Guid surveyId, [Authorize("Bearer")] string token);
    }
}
