using System.ComponentModel.DataAnnotations;

namespace CoreProjectPortfolio.Areas.User.Models
{
    public class UserRegisterViewModel
        //burada gerekli tanımlamaları yaptıktan sonra entitylayer.conrete
        //içerisine writeruser adında gerekli sınıfı oluştur.
    {

        [Required(ErrorMessage = "Lütfen Adınızı Giriniz.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen Soyadınızı Giriniz.")]
        public string Surname { get; set; }
        [Required(ErrorMessage ="Lütfen Kullanıcı Adınızı Giriniz.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lütfen Şifreiniz  Giriniz.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Lütfen Şifreyi Tekrar Girin.")]
        [Compare("Password",ErrorMessage ="Şifreler Uyumlu Değil")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Lütfen Resim Linkini Giriniz.")]
        public string ImageUrl { get; set; }
        public string Mail { get; set; }
        //Buraya Gerekli Atamalarımı Context sınıfımda gerçekleştirdim
    }
}
//comfirmpassword propuma tanımladığım "Compare" metodu ConfirmPassworda girilen
//değerin Password propumla karşılaştırır uyumluysa işlemlere devam eder
//değilse hata mesajı verir->şifreler uyumlu değil