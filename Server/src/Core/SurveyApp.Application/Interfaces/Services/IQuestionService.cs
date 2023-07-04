using SurveyApp.Application.Dtos.Requests;
using SurveyApp.Application.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Interfaces.Services
{
    public interface IQuestionService
    {
        Task<int> AddAsync(CreateQuestionRequest request);
        Task<int> AddRangeAsync(IEnumerable<CreateQuestionRequest> request, Guid id);
        Task DeleteRangeAsync(List<int> removedQuestions);
        Task<QuestionResponse> GetQuestionByIdAsync(int id);
        Task<IEnumerable<QuestionResponse>> GetQuestionsBySurveyIdAsync(Guid surveyId);
        Task UpdateAsync(UpdateQuestionRequest question);
        Task UpdateRangeAsync(List<UpdateQuestionRequest> questions);
    }
}
