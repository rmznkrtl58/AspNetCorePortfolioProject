using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreProjectPortfolio.ViewComponents.Dashboard
{
    public class FeatureStatistick:ViewComponent
    {
        Context ent = new Context();
        public IViewComponentResult Invoke()
        {   //Yetenek Sayısı
            ViewBag.s1 = ent.Skills.Count();
            //Okunmuş Mesaj sayısı
            ViewBag.s2 = ent.Messages.Where(x => x.Status == true).Count();
            //Okunmamış mesaj sayısı
            ViewBag.s3= ent.Messages.Where(x => x.Status == false).Count();
            //Çalışılan firma sayısı
            ViewBag.s4=ent.Experiences.Count();
            return View();
        }
    }
}
