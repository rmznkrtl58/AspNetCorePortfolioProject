using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace CoreProjectPortfolio.ViewComponents.Portfolio
{
    public class PortfolioList:ViewComponent
    {
        PortfolioManager bm = new PortfolioManager(new EFPortfolioDal());
        public IViewComponentResult Invoke()
        {   
            var values=bm.TGetList();
            return View(values);
        }
    }
}
