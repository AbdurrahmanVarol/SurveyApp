using Microsoft.AspNetCore.Mvc;
using SurveyApp.MVC.Models;

namespace SurveyApp.MVC.Controllers
{
    public class SurveyController : Controller
    {
        [HttpGet]
        public IActionResult CreateSurvey()
        {
            //Todo:questiontype ı cache ten al
            return View();
        }
        [HttpPost]
        public IActionResult CreateSurvey(CreateSurveyModel createSurveyModel)
        {

            TempData["CreateSurvey"] = "Anket Oluşturuldu";
            return View();
        }
    }
}
