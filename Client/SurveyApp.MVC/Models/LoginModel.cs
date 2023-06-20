using System.ComponentModel.DataAnnotations;

namespace SurveyApp.MVC.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre adı boş geçilemez!")]
        public string Password { get; set; }
        public bool IsKeepLoggedIn { get; set; }
    }
}
