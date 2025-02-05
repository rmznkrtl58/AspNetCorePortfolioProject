using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjectPortfolio.Areas.User.Controllers
{
    [Area("User")]//Default controllerimi hangi are'aya ait olduğunu bildirdim.
    [Route("User/[controller]/[action]")]//yönlendirmelerimi yapmamı sağlayacak yapı
    public class DefaultController : Controller
    {
        AnnouncementManager AnnouncementManager = new AnnouncementManager(new EfAnnouncementDal());
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            var values = AnnouncementManager.TGetList();
            return View(values);
        }
        [Route("Getdetails/{id}")]
        public IActionResult Getdetails(int id)
        {   
            var getAnnouncement=AnnouncementManager.TGetById(id);
            return View(getAnnouncement);
        }
    }
}
