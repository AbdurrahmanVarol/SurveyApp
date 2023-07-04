using SurveyApp.Application.Dtos.Responses;
using SurveyApp.Domain.ComplexTypes;
using SurveyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Interfaces.Repositories
{
    public interface IAnswerRepository : IEntityRepository<Answer>
    {
        Task<SurveyResult?> GetAnswerResultsBySurveyIdAsync(Guid surveyId);
        Task<IEnumerable<AnswerResult>> GetAnswerResultByQuestionIdAsync(int questionId);
    }
}
