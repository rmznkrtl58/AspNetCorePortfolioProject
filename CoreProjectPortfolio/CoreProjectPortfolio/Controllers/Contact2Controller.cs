using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjectPortfolio.Controllers
{
    public class Contact2Controller : Controller
    {
        ContactManager cm = new ContactManager(new EFContactDal());
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.v1 = "Güncelleme";
            ViewBag.v2 = "İletişim Güncelleme";
            ViewBag.v3 = "Güncelleme";
            int id = 1;
            var values = cm.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult Index(Contact c)
        {
            cm.TUpdate(c);
            return RedirectToAction("Index","Contact2");
        }
    }
}
