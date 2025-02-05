using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjectPortfolio.Controllers
{
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EFaboutDal());
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.v1 = "Hakkımda";
            ViewBag.v2 = "Hakkımda Düzenleme";
            ViewBag.v3 = "Hakkımda";
            var values = abm.TGetById(1);
            return View(values);
        }
        [HttpPost]
        public IActionResult Index(About a)
        {  
            abm.TUpdate(a);
            return RedirectToAction("Index","About");
        }
    }
}
