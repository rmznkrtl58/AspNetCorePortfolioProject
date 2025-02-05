using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreProjectPortfolio.ViewComponents.Dashboard
{
    public class DashboardStatistick2:ViewComponent
    {
        Context ent = new Context();
        public IViewComponentResult Invoke()
        {
            //Tamamlanan toplam proje sayısı
            ViewBag.s1 = ent.portfolios.Where(z => z.Value == 100).Count();
            //Son gelen mesajlar 
            ViewBag.s2 = ent.Messages.Where(x => x.Status == true).Count();
            //Verilen Toplam Hizmet Sayısı
            ViewBag.s3 = ent.services.Count();
            return View();
        }
    }
}
