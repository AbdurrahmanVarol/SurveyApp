using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SurveyApp.MVC.Filters;
using SurveyApp.MVC.Models;
using SurveyApp.MVC.Refit;
using System.Drawing.Printing;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace SurveyApp.MVC.Controllers
{
    [CustomExceptionFilter]
    public class SurveyController : Controller
    {
        private readonly ISurveyApi _surveyApi;
        private readonly IAnswerApi _answerApi;

        private string Token => User.Claims.First(x => x.Type == "token").Value;

        public SurveyController(ISurveyApi surveyApi, IAnswerApi answerApi)
        {
            _surveyApi = surveyApi;
            _answerApi = answerApi;
        }

        [HttpGet]
        [Authorize]
        public IActionResult CreateSurvey()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateSurvey([FromBody] CreateSurveyModel createSurveyModel)
        {

            var response = await _surveyApi.CreateSurveyAsync(createSurveyModel, Token);



            TempData["CreateSurvey"] = "Anket Oluşturuldu";
            return Json(new
            {
                isSuccess = response.IsSuccessStatusCode,
                surveyId = response.Content
            });
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> UpdateSurvey(Guid surveyId)
        {
            var survey = await _surveyApi.GetSurveyForUpdateById(surveyId);

            if(survey is null)
            {
                return RedirectToAction("NotFoundPage", "Home");
            }

            return View(survey);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UpdateSurvey([FromBody] UpdateSurveyModel createSurveyModel)
        {
            await _surveyApi.UpdateSurveyAsync(createSurveyModel, Token);

            TempData["CreateSurvey"] = "Anket Oluşturuldu";
            return View();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> CreatedSurveys()
        {
            var surveys = await _surveyApi.GetCreatedSurveysAsync(Token);

            return View(surveys);
        }

        [HttpGet]
        public IActionResult SurveyDetail(Guid survey)
        {

            var survetDetail = _surveyApi.GetSurveyById(survey).GetAwaiter().GetResult();
            if (survetDetail is null)
            {
                return RedirectToAction("notfound", "home");
            }

            return View(survetDetail);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> SurveyResult(Guid surveyId)
        {

            var surveyResult = await _answerApi.GetSurveyResultById(surveyId,Token);

            if (surveyResult is null)
            {
                return RedirectToAction("notfound", "home");
            }

            return View(surveyResult);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> DeleteSurvey(Guid surveyId)
        {

            await _surveyApi.DeleteSurveyAsync(surveyId, Token);

            var surveys = await _surveyApi.GetCreatedSurveysAsync(Token);

            TempData["Message"] = "Anket Silindi";

            return RedirectToAction(nameof(CreatedSurveys));
        }
    }
}
