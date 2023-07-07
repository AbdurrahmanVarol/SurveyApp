using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using SurveyApp.MVC.Models;
using Refit;
using System;
using SurveyApp.MVC.Refit;
using SurveyApp.MVC.Filters;

namespace SurveyApp.MVC.Controllers
{
    [CustomExceptionFilter]
    public class AuthController : Controller
    {
        private readonly IAuthApi _authApi;

        public AuthController(IAuthApi authApi)
        {
            _authApi = authApi;
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
            var response = await _authApi.LoginAsync(loginModel);

            if (!response.IsSuccessStatusCode)
            {
                TempData["LoginException"] = "Kullanıcı adı ya da şifre hatalı";
                return View();
            }

            var claims = new List<Claim>
                {
                    new Claim("token" ,response.Content.Token),
                    new Claim("refreshToken",response.Content.RefreshToken),
                    new Claim(ClaimTypes.Name, response.Content.UserName)
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
            var response = await _authApi.RegisterAsync(registerRequest);

            if(!response.IsSuccessStatusCode)
            {
                TempData["Register"] = "Kayıt olunamadı";
            }

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
