using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SurveyApp.MVC.Models;
using SurveyApp.MVC.Refit;
using System.Drawing.Printing;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace SurveyApp.MVC.Controllers
{
    public class SurveyController : Controller
    {
        private readonly ISurveyApi _surveyApi;

        private string Token => User.Claims.First(x => x.Type == "token").Value;

        public SurveyController(ISurveyApi surveyApi)
        {
            _surveyApi = surveyApi;
        }

        [HttpGet]
        [Authorize]
        public IActionResult CreateSurvey()
        {
            //Todo:questiontype ı cache ten al
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateSurvey([FromBody] CreateSurveyModel createSurveyModel)
        {
            //TODO:
            createSurveyModel.CreatedAt = DateTime.Now;
            var id = await _surveyApi.CreateSurveyAsync(createSurveyModel, Token);

            var encodedId = Convert.ToBase64String(Encoding.UTF8.GetBytes(id.ToString()));

            

            TempData["CreateSurvey"] = "Anket Oluşturuldu";
            return Json(new
            {
                surveyId = encodedId
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
            ////TODO:
            //createSurveyModel.CreatedAt = DateTime.Now;
            //var id = await _surveyApi.CreateSurveyAsync(createSurveyModel, Token);

            //var encodedId = Convert.ToBase64String(Encoding.UTF8.GetBytes(id.ToString()));

            TempData["CreateSurvey"] = "Anket Oluşturuldu";
            return Json(new
            {
                surveyId = 1
            });
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
        public IActionResult SurveyResult()
        {
        //        var survetDetail = _surveyApi.GetSurveyById(surveyId);

        //        if (survetDetail is null)
        //        {
        //            return RedirectToAction("notfound", "home");
        //        }

                return View();
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
