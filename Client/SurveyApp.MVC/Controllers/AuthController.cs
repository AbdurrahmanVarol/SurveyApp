using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using SurveyApp.MVC.Models;

namespace SurveyApp.MVC.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            //try
            //{
            //    var user = _authService.LoginAsync(loginRequest).GetAwaiter().GetResult();

            //    var claims = new List<Claim>
            //    {
            //        new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            //        new Claim("Name",user.FirstName),
            //        new Claim("FullName",user.FullName)
            //    };

            //    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            //    var authenticationProperties = new AuthenticationProperties
            //    {
            //        AllowRefresh = true,
            //        IsPersistent = loginModel.IsKeepLoggedIn,

            //    };

            //    HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity), authenticationProperties).GetAwaiter().GetResult();
            //    return RedirectToAction("index", "home");
            //}
            //catch (Exception exception)
            //{
            //    TempData["LoginException"] = exception.Message;
            //    return View();
            //}

            return View();
        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync().GetAwaiter().GetResult();
            return RedirectToAction("login");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel registerRequest)
        {
            //await _authService.RegisterAsync(registerRequest);
            return Json(new
            {
                isSuccess = true,
            });
        }
    }
}
