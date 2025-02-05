using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjectPortfolio.ViewComponents.About
{
    public class AboutList:ViewComponent
    {
        AboutManager abm = new AboutManager(new EFaboutDal());
        public IViewComponentResult Invoke()
        {
            var aboutlist = abm.TGetList();
            return View(aboutlist);
        }
    }
}
