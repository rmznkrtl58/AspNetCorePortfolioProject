using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjectPortfolio.Controllers
{
    public class FeatureController : Controller
    {
        FeatureManager fm = new FeatureManager(new EFFeatureDal());
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.v1 = "Öne Çıkanlar";
            ViewBag.v2 = "Öne Çıkan Düzenle";
            ViewBag.v3 = "Öne Çıkanlar";
            var values = fm.TGetById(1);
            return View(values);
        }
        [HttpPost]
        public IActionResult Index(Feature f)
        {   
            fm.TUpdate(f);
            return RedirectToAction("Index","Feature");
        }
        public PartialViewResult PartialSideBar()
        {
            return PartialView();
        }
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult HeadPartial()
        {
            return PartialView();
        }
        public PartialViewResult ScriptPartial()
        {
            return PartialView();
        }
        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }
    }
}
