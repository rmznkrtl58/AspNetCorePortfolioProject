using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjectPortfolio.Controllers
{
    public class ServiceController : Controller
    {
        ServiceManager sm = new ServiceManager(new EFServiceDal());
        public IActionResult Index()
        {
            ViewBag.v1 = "Hizmet";
            ViewBag.v2 = "Hizmetlerin Listesi";
            ViewBag.v3 = "Hizmet";
            var servicelist = sm.TGetList();
            return View(servicelist);
        }
        [HttpGet]
        public IActionResult addservice()
        {
            ViewBag.v1 = "Ekleme";
            ViewBag.v2 = "Hizmet Ekleme";
            ViewBag.v3 = "Ekleme";
            return View();
        }
        [HttpPost]
        public IActionResult addservice(Service s)
        {
            s.ImageUrl = "/template/images/services/web-design.svg";
            sm.TAdd(s);
            return RedirectToAction("Index","Service");
        }
        public IActionResult deleteservice(int id)
        {   var serviceid = sm.TGetById(id);
            sm.TRemove(serviceid);
            return RedirectToAction("Index", "Service");
        }
        [HttpGet]
        public IActionResult getservice(int id)
        {
            ViewBag.v1 = "Güncelleme";
            ViewBag.v2 = "Hizmet Güncelleme";
            ViewBag.v3 = "Güncelleme";
            var values=sm.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult getservice(Service s)
        {
            s.ImageUrl = "/template/images/services/web-design.svg";
            sm.TUpdate(s);
            return RedirectToAction("Index","Service");
        }
    }
}
