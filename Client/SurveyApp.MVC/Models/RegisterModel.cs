using System.ComponentModel.DataAnnotations;

namespace SurveyApp.MVC.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Ad boş geçilemez!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Soyad boş geçilemez!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email boş geçilemez!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre boş geçilemez!")]
        public string Password { get; set; }
        [Compare(otherProperty: "Password", ErrorMessage = "Şifre ve şifre tekrar aynı olmalı!")]
        [Required(ErrorMessage = "Şifre tekrar boş geçilemez!")]
        public string PasswordConfirm { get; set; }
    }
}
