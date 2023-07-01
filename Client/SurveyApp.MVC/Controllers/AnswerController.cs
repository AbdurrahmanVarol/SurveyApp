using Microsoft.AspNetCore.Mvc;
using SurveyApp.MVC.Models;
using SurveyApp.MVC.Refit;

namespace SurveyApp.MVC.Controllers
{
    public class AnswerController : Controller
    {
        private readonly IAnswerApi _answerApi;

        public AnswerController(IAnswerApi answerApi)
        {
            _answerApi = answerApi;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnswer([FromBody]AnswerModel answerModel)
        {
            await _answerApi.CreateOptionalAnswers(answerModel.OptionalAnswers);
            await _answerApi.CreateTextAnswers(answerModel.TextAnswers);
            return Ok(answerModel);
        }
    }
}
