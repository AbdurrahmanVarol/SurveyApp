using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using SurveyApp.MVC.Models;
using Refit;
using System;
using SurveyApp.MVC.Refit;

namespace SurveyApp.MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthApi _surveyAppApi;

        public AuthController(IAuthApi surveyAppApi)
        {
            _surveyAppApi = surveyAppApi;
        }

        [HttpGet]
        public IActionResult Login(string? returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel, string? returnUrl)
        {
            try
            {
                var result = await _surveyAppApi.LoginAsync(loginModel);

                var claims = new List<Claim>
                {
                    new Claim("token" ,result.Token),
                    new Claim("refreshToken",result.RefreshToken),
                    new Claim(ClaimTypes.Name, result.UserName)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authenticationProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    IsPersistent = loginModel.IsKeepLoggedIn,
                };

                await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity), authenticationProperties);

                if (string.IsNullOrWhiteSpace(returnUrl))
                {
                    return RedirectToAction("index", "home");
                }
                return Redirect(returnUrl);
            }
            catch (Exception exception)
            {
                TempData["LoginException"] = exception.Message;
                return View();
            }
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
            var result = await RestService.For<IAuthApi>("https://localhost:7193/api").RegisterAsync(registerRequest);

            TempData["Register"] = "Kayıt olundu";
            return View();
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
