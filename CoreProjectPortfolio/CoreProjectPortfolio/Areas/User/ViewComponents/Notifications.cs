using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjectPortfolio.Areas.User.ViewComponents
{   
    public class Notifications:ViewComponent
    {
        AnnouncementManager AnnouncementManager = new AnnouncementManager(new EfAnnouncementDal());
        public IViewComponentResult Invoke()
        {
            var AnnouncementList = AnnouncementManager.TGetList();
            return View(AnnouncementList);
        }
    }
}
