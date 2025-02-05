using Microsoft.AspNetCore.Http;

namespace CoreProjectPortfolio.Areas.User.Models
{
    public class UserEditViewModel
    //Sisteme Authontice olan Kullanıcının Bilgilerini
    //Güncellemek için kurduğumuz classtır
    //hangi bilgileri güncellemek istiyorsak onların proplarını tanımladım.
    //Buradaki her bir propun ismi aspnetuser tablomdaki proplarla eşit olmalı  
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string PictureUrl { get; set; }
        //wwwroot'a kaydeteceğimiz resim için IFormFile Türü kullanıyoz
        public IFormFile Picture { get; set; }
    }
}
