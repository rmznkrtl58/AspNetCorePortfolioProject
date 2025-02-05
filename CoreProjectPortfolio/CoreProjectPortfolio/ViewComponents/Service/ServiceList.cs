using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjectPortfolio.ViewComponents.Service
{
    public class ServiceList:ViewComponent
    {
        ServiceManager sm = new ServiceManager(new EFServiceDal());
        public IViewComponentResult Invoke()
        {
            var ServiceList = sm.TGetList();
            return View(ServiceList);
        }
    }
}
