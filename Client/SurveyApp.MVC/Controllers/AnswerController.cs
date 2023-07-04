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
        public async Task<IActionResult> CreateAnswer([FromBody]AnswerModel surveyAnswers)
        {
            var response = await _answerApi.CreateSurveyAnswers(surveyAnswers);
            //var optionalResponse = await _answerApi.CreateOptionalAnswers(answerModel.OptionalAnswers);
            //var textResponse = await _answerApi.CreateTextAnswers(answerModel.TextAnswers);

            return Json(new {
                isSuccess = response.IsSuccessStatusCode
            });
        }
    }
}
