using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjectPortfolio.Controllers
{
    public class TestimonialController : Controller
    {
        TestimonialManager tm = new TestimonialManager(new EFTestimonialDal());
        public IActionResult Index()
        {
            var values = tm.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Addtestimonial()
        {
            ViewBag.v1 = "Ekleme";
            ViewBag.v2 = "Referans Ekleme";
            ViewBag.v3 = "Ekleme";
            return View();
        }
        [HttpPost]
        public IActionResult Addtestimonial(Testimonial t)
        {
            tm.TAdd(t);
            return RedirectToAction("Index","Testimonial");
        }
        public IActionResult Deletetestimonial(int id)
        {
            var findtestimonial=tm.TGetById(id);
            tm.TRemove(findtestimonial);
            return RedirectToAction("Index", "Testimonial");
        }
        [HttpGet]
        public IActionResult Gettestimonial(int id)
        {
            ViewBag.v1 = "Güncelleme";
            ViewBag.v2 = "Referans Güncelleme";
            ViewBag.v3 = "Güncelleme";
            var values = tm.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult Gettestimonial(Testimonial t)
        {
            ViewBag.v1 = "Güncelleme";
            ViewBag.v2 = "Referans Güncelleme";
            ViewBag.v3 = "Güncelleme";
            tm.TUpdate(t);
            return RedirectToAction("Index","Testimonial");
        }
    }
}
