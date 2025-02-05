using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjectPortfolio.ViewComponents.Dashboard
{
    public class DashboardProjectList:ViewComponent
    {
        PortfolioManager pm = new PortfolioManager(new EFPortfolioDal());
        public IViewComponentResult Invoke()
        {
            var projectlist = pm.TGetList();
            return View(projectlist);
        }
    }
}
