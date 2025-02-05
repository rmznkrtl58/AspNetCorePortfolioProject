using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjectPortfolio.ViewComponents.Dashboard
{
    public class DashboardMessages:ViewComponent
    {
        //UserMessageManager um = new UserMessageManager(new EfUserMessageDal());
        public IViewComponentResult Invoke()
        {
            //var values = um.GetUserMessageWithUserService();
            return View();
        }
    }
}
