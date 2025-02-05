using CoreProjectPortfolio.Areas.User.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace CoreProjectPortfolio.Areas.User.Controllers
{
    [AllowAnonymous]
    [Area("User")] //bunu yazmayı unutma açılmaz
    [Route("User/[controller]/[action]")]
    public class RegisterController : Controller
    {   
        private readonly UserManager<WriterUser> _userManager;
                                             //_userManager ctrl+"." constructor metod uygula 

        public RegisterController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(new UserRegisterViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel p)
        {   //async metod olarak task içinde yazma sebebim içeride async'bir işlem yapmamdan
            //kaynaklı
            if (ModelState.IsValid)//userregisterviewmodel'imde şartlar sağlandıysa (doğrulama başarılıysa)
            {
                WriterUser wu = new WriterUser()
                {
                    //UserRegisterViewModel'e bağlı olan p parametreme gelen değerleri
                    //writeruser'a bağlı olan nesnelerime atamalarımı yaptım
                    Name = p.Name,
                    Surname = p.Surname,
                    UserName = p.UserName,
                    ImageUrl = p.ImageUrl,
                    Email = p.Mail
                };
                if (p.Password == p.ConfirmPassword)
                {
                    var result = await _userManager.CreateAsync(wu, p.Password);
                    //Hesap oluşturulmada WriterUser->wu,Password->p.password
                    //password tarafına yukarda atama yapmadım burada kullandığım için
              
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach(var x in result.Errors)
                    {
                        ModelState.AddModelError("", x.Description);
                                 //x.description->hata mesajı
                    }
                }
                
                }
            }
            return View();
        }
    }   //eğerki login form gelmiyor while attempting to active hatası varsa 
        //startup tarafında ConfigureServices metodu içerisine gidip gör ne yazdığını
}

