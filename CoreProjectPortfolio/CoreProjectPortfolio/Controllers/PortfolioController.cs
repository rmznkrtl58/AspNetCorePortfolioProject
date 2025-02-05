using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace CoreProjectPortfolio.Controllers
{
    public class PortfolioController : Controller
    {
        PortfolioManager pm = new PortfolioManager(new EFPortfolioDal());
        public IActionResult Index()
        {
            ViewBag.v1 = "Projeler";
            ViewBag.v2 = "Proje Listesi";
            ViewBag.v3 = "Projeler";
            var pflist = pm.TGetList();
            return View(pflist);
        }
        [HttpGet]
        public IActionResult addportfolio()
        {
            ViewBag.v1 = "Ekleme";
            ViewBag.v2 = "Proje Ekleme";
            ViewBag.v3 = "Ekleme";
            return View();
        }
        [HttpPost]
        public IActionResult addportfolio(Portfolio p)
        {
            p.Status = true;
            p.SliderImage = "/template/images/portfolio/1.jpg";
            PortfolioValidator pvalidation = new PortfolioValidator();
            //use.fluent validation
            ValidationResult results= pvalidation.Validate(p);//p'deki doğrulamaları kontrol et
            if (results.IsValid)//doğrulamalar başarılı geçtiyse
            {
                pm.TAdd(p);
                return RedirectToAction("Index", "Portfolio");
            }
            else
            {
                foreach(var x in results.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
            }
            return View();
        }
        public IActionResult deleteportfolio(int id)
        {
            var pfid = pm.TGetById(id);
            pm.TRemove(pfid);
            return RedirectToAction("Index", "Portfolio");
        }
        [HttpGet]
        public IActionResult getportfolio(int id)
        {
            ViewBag.v1 = "Güncelleme";
            ViewBag.v2 = "Proje Güncelleme";
            ViewBag.v3 = "Güncelleme";
            var values=pm.TGetById(id);
            values.Status = true;
            return View(values);
        }
        [HttpPost]
        public IActionResult getportfolio(Portfolio p)
        {
            p.Status = true;
            p.SliderImage = "/template/images/portfolio/1.jpg";
            pm.TUpdate(p);
            return RedirectToAction("Index", "Portfolio");
        }
    }
}
