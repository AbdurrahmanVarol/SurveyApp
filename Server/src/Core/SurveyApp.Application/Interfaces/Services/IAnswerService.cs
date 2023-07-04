using SurveyApp.Application.Dtos.Requests;
using SurveyApp.Application.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Interfaces.Services
{
    public interface IAnswerService
    {
        Task<SurveyResultResponse> GetAnswerResultsBySurveyIdAsync(Guid surveyId, Guid userId);
        Task<IEnumerable<AnswerResultResponse>> GetAnswerResultByQuestionIdAsync(int questionId);
        Task<int> AddAsync(CreateAnswerRequest request);
        Task AddRangeAsync(IEnumerable<CreateAnswerRequest> request);
    }
}
