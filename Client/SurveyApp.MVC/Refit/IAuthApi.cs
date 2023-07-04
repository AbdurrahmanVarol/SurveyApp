using Refit;
using SurveyApp.MVC.Models;

namespace SurveyApp.MVC.Refit
{
    public interface IAuthApi
    {
        [Post("/auth/login")]
        Task<ApiResponse<AuthModel>> LoginAsync(LoginModel loginModel);

        [Post("/auth/register")]
        Task<ApiResponse<UserModel>> RegisterAsync(RegisterModel registerModel);

    }
}
