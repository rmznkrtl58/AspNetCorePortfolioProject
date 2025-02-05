using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjectPortfolio.Controllers
{
     [Authorize(Roles = "Admin")]
    public class ExperienceController : Controller
    {
        
        ExperienceManager em = new ExperienceManager(new EFExperienceDal());
       
        public IActionResult Index()
        {
            ViewBag.v1 = "Listeleme";
            ViewBag.v2 = "Deneyim Listesi";
            ViewBag.v3 = "Listeleme";
            var explist = em.TGetList();
            return View(explist);
        }
        [HttpGet]
        public IActionResult addexperience()
        {
            ViewBag.v1 = "Ekleme";
            ViewBag.v2 = "Deneyim Ekleme";
            ViewBag.v3 = "Ekleme";
            return View();
        }
        [HttpPost]
        public IActionResult addexperience(Experience e)
        {
            em.TAdd(e);
            return RedirectToAction("Index","Experience");
        }
        public IActionResult deleteexperience(int id)
        {   
            //silme işlemi id'yi bulduktan sonra gerçekleşmeli
            var exid=em.TGetById(id);
            em.TRemove(exid);
            return RedirectToAction("Index", "Experience");
        }
        [HttpGet]
        public IActionResult getexperience(int id)
        {
            ViewBag.v1 = "Güncelleme";
            ViewBag.v2 = "Deneyim Güncelleme";
            ViewBag.v3 = "Güncelleme";
            var values = em.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult getexperience(Experience e)
        {   //gerekli bilgiler otomatik olarak sayfada olduğu için
            //hiddenlada id'yi tuttuğumuz için herhangi bir getbyid
            //kullanmamıza gerek yok
            em.TUpdate(e);
            return RedirectToAction("Index","Experience");
        }
    }
}
