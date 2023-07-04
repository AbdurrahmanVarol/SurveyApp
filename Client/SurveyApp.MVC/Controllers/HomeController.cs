using Microsoft.AspNetCore.Mvc;
using SurveyApp.MVC.Models;
using SurveyApp.MVC.Refit;
using System.Diagnostics;

namespace SurveyApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISurveyApi _surveyApi;

        public HomeController(ILogger<HomeController> logger, ISurveyApi surveyApi)
        {
            _logger = logger;
            _surveyApi = surveyApi;
        }

        public async Task<IActionResult> Index()
        {
            var surveys = await _surveyApi.GetSurveys();
            return View(surveys);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(ErrorViewModel model)
        {
            return View(model);
        }

        [HttpGet]
        public IActionResult NotFoundPage()
        {
            return View();
        }
    }
}