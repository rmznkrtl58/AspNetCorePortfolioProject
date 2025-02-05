using CoreProjectPortfolio.Areas.User.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CoreProjectPortfolio.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<WriterUser> _usermanager;

        public ProfileController(UserManager<WriterUser> writeruser)
        {
            _usermanager = writeruser;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {   //sisteme authontice olan birinin bilgilerini text boxlara getirme
            var finduser = await _usermanager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();
            model.PictureUrl = finduser.ImageUrl;
            model.Name= finduser.Name;
            model.Surname= finduser.Surname;
            return View(model);
        }
        //KULLANICI BİLGİLERİNİ GÜNCELLEME
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {   //sisteme authontice olan birinin bilgilerini getirmek için finduser
            //değişkenime atama yaptım 
            var Finduser = await _usermanager.FindByNameAsync(User.Identity.Name);
            
            if (p.Picture != null)//resim yükleme alanında resimi seçtiğimiz zaman
            {              //directory->system.ıo
                var source = Directory.GetCurrentDirectory();//seçtiğimiz resmin aktif yolunu al
                var extension = Path.GetExtension(p.Picture.FileName);//dosyanın uzantısını al
                var imagename = Guid.NewGuid() + extension;//resmin adını al-> favicon.png
                var savelocation = source + "/wwwroot/userimg/" + imagename;//kaydediceği yer
                var stream = new FileStream(savelocation, FileMode.Create);//Dosya Akışının konumu ve 
                                                                           //oluşturulması
                await p.Picture.CopyToAsync(stream);//resmin dosyasını akıştaki duruma göre kopyala
                Finduser.ImageUrl = imagename;
                //örnek resim uzantısı->"~/skydash/images/favicon.png"
            }
            if (p.Picture != null || p.Password == null || p.PasswordConfirm == null) { 
            Finduser.Name = p.Name;
            Finduser.Surname= p.Surname;
            Finduser.PasswordHash = _usermanager.PasswordHasher.HashPassword(Finduser, p.Password);
            var result=await _usermanager.UpdateAsync(Finduser);
                
            //registerda->CreateAsync loginde->PasswordSignInAsync
            //updatede->UpdateAsync kullandık
            if (result.Succeeded) 
            {
                return RedirectToAction("Index", "Default");
            }
            }
            return View();
        }
        
        //public async Task<PartialViewResult> ProfileImage()
        //{
        //    var finduser = await _usermanager.FindByNameAsync(User.Identity.Name);
        //    ViewBag.img = finduser.ImageUrl;
        //    return PartialView(finduser);
        //}
    }
}
