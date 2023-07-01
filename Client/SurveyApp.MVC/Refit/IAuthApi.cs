using Refit;
using SurveyApp.MVC.Models;

namespace SurveyApp.MVC.Refit
{
    public interface IAuthApi
    {
        [Post("/auth/login")]
        Task<AuthModel> LoginAsync(LoginModel loginModel);

        [Post("/auth/register")]
        Task<UserModel> RegisterAsync(RegisterModel registerModel);

    }
}
