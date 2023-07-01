using SurveyApp.MVC.Models;
using SurveyApp.MVC.Refit;

namespace SurveyApp.MVC.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerApi _answerApi;

        public AnswerService(IAnswerApi answerApi)
        {
            _answerApi = answerApi;
        }

        public async Task CreateAnswers(AnswerModel answer)
        {
            await _answerApi.CreateOptionalAnswers(answer.OptionalAnswers);
            await _answerApi.CreateTextAnswers(answer.TextAnswers);
        }
    }
}
