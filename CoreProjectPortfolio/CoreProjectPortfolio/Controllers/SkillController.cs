using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjectPortfolio.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SkillController : Controller
    {
        SkillManager sm = new SkillManager(new EFSkillDal());
        public IActionResult Index()
        {   //Header alanımdaki sayfamın hangi sayfada olduğunu gösteren
            //bir kısım var, viewbaglarimize verilerimizi tanımladık
            //listeleme zamanında orada viewbagda atanan veriler gelecek
            //HeaderPartial->sayfamda bulunan ilgili yerlere viewbag'leri
            //tanımladık->partial viewler async yapısına sahip olduğu için
            //yani aynı anda birden fazla işi yapabilme yeteneğine sahip 
            //oldukları için her sayfamda gerekli veriler gelecektir
            ViewBag.v1 = "Yetenek";
            ViewBag.v2 = "Yetenek Listesi";
            ViewBag.v3 = "Yetenekler";
            var SkillList = sm.TGetList();
            return View(SkillList);
        }
        [HttpGet]
        public IActionResult addskill()
        {
            //yetenek ekleme sayfası yüklenince aşağıdaki değerler
            //HeaderPartial tarafında otomatik olarak gelecek yukarıda açıkladım
            ViewBag.v1 = "Ekleme";
            ViewBag.v2 = "Yetenek Ekle";
            ViewBag.v3 = "Ekleme";
            return View();
        }
        [HttpPost]
        public IActionResult addskill(Skill s)
        {
            sm.TAdd(s);
            return RedirectToAction("Index","Skill");
        }
        public ActionResult deleteskill(int id)
        {   
            var skillid=sm.TGetById(id);
            sm.TRemove(skillid);
            return RedirectToAction("Index","Skill");
        }
        [HttpGet]
        public IActionResult getskill(int id)
        {
            ViewBag.v1 = "Güncelle";
            ViewBag.v2 = "Yetenek Güncelle";
            ViewBag.v3 = "Güncelle";
            var skillid = sm.TGetById(id);
            return View(skillid);
        }
        [HttpPost]
        public IActionResult getskill(Skill s)
        {
            sm.TUpdate(s);
            return RedirectToAction("Index","Skill");
        }
    }
}
