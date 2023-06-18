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
        Task<IEnumerable<AnswerResultResponse>> GetAnswerResultsBySurveyIdAsync(int surveyId);
        Task<AnswerResultResponse> GetAnswerResultByQuestionIdAsync(int questionId);
        Task<int> AddAsync(CreateAnswerRequest request);
    }
}
