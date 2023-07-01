using SurveyApp.Application.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Interfaces.Services
{
    public interface IQuestionTypeService
    {
        Task<IEnumerable<QuestionTypeResponse>> GetAll();
    }
}
