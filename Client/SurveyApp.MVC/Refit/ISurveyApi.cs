using Refit;
using SurveyApp.MVC.Models;

namespace SurveyApp.MVC.Refit
{
    public interface ISurveyApi
    {
        [Get("/surveys/{id}")]
        Task<SurveyModel> GetSurveyById(Guid id); 
        
        [Get("/surveys/surveyForUpdate/{id}")]
        Task<SurveyDisplayForUpdateModel> GetSurveyForUpdateById(Guid id);
        
        //Todo: /surveys?created_by=abdurrahman
        // surveys/my
        [Get("/surveys/GetCreatedSurveys")]
        Task<IEnumerable<SurveyDisplayModel>> GetCreatedSurveysAsync([Authorize("Bearer")] string token);
        
        [Post("/surveys")]
        Task<int> CreateSurveyAsync(CreateSurveyModel createSurveyModel, [Authorize("Bearer")] string token);
        
        [Delete("/surveys")]
        Task DeleteSurveyAsync(Guid surveyId, [Authorize("Bearer")] string token);

    }
}
