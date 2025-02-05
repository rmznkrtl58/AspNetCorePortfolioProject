using System.ComponentModel.DataAnnotations;

namespace CoreProjectPortfolio.Areas.User.Models
{   //Buradaki her bir propun ismi aspnetuser tablomdaki proplarla eşit olmalı  
    public class UserLoginViewModel
    {
        [Display(Name ="Kullanıcı Adı")]
        [Required(ErrorMessage ="Kullanıcı adınızı giriniz...")]
        public string Username { get; set; }
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifrenizi giriniz...")]
        public string Password { get; set; }
    }
}
