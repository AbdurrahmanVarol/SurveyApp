using Refit;
using SurveyApp.MVC.Models;

namespace SurveyApp.MVC.Refit
{
    public interface ISurveyApi
    {
        [Get("/surveys")]
        Task<IEnumerable<SurveyDisplayModel>> GetSurveys(); 

        [Get("/surveys/{id}")]
        Task<SurveyModel> GetSurveyById(Guid id); 
        
        [Get("/surveys/surveyForUpdate/{id}")]
        Task<SurveyDisplayForUpdateModel> GetSurveyForUpdateById(Guid id);

        [Get("/surveys/GetCreatedSurveys")]
        Task<IEnumerable<SurveyDisplayModel>> GetCreatedSurveysAsync([Authorize("Bearer")] string token);
        
        [Post("/surveys")]
        Task<ApiResponse<int>> CreateSurveyAsync(CreateSurveyModel createSurveyModel, [Authorize("Bearer")] string token);

        [Put("/surveys")]
        Task<IApiResponse> UpdateSurveyAsync(UpdateSurveyModel updateSurveyModel, [Authorize("Bearer")] string token);
        
        [Delete("/surveys")]
        Task DeleteSurveyAsync(Guid surveyId, [Authorize("Bearer")] string token);

    }
}
