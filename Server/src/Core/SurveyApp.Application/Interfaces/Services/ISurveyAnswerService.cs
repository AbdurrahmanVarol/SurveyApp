using SurveyApp.Application.Dtos.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Interfaces.Services
{
    public interface ISurveyAnswerService
    {
        Task CreateSurveyAnswersAsync(CreateSurveyAnswerRequest request);
    }
}
