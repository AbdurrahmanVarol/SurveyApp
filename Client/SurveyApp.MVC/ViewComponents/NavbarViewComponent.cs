using Microsoft.AspNetCore.Mvc;
using SurveyApp.MVC.Models;
using System.Security.Claims;

namespace SurveyApp.MVC.ViewComponents
{
    public class NavbarViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userName = HttpContext.User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.Name)?.Value;
            var isAuthenticated = HttpContext.User.Identity?.IsAuthenticated ?? false;
            return View(new NavbarViewModel
            {
                IsAuthenticated = isAuthenticated,
                UserName = userName,
            });
        }
    }
}
