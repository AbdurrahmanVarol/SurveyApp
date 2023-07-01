using SurveyApp.Application.Dtos.Requests;
using SurveyApp.Application.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Interfaces.Services
{
    public interface ISurveyService
    {
        Task<SurveyResponse> GetSurveyByIdAsync(Guid id);
        Task<IEnumerable<SurveyDisplayResponse>> GetSurveysAsync();        
        Task<Guid> AddAsync(CreateSurveyRequest request);
        Task<IEnumerable<SurveyDisplayResponse>> GetSurveysByUserIdAsync(Guid userId);
        Task DeleteAsync(Guid surveyId);
        Task<SurveyDiplayForUpdateResponse> GetSurveyForUpdateByIdAsync(Guid id);
    }
}
