using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjectPortfolio.Controllers
{
    public class ContactController : Controller
    {
        MessageManager mm = new MessageManager(new EFMessageDal());
        public IActionResult Index()
        {
            var messagelist = mm.TGetList();
            return View(messagelist);
        }
        public IActionResult deletemessage(int id)
        {
            var findmessage = mm.TGetById(id);
            mm.TRemove(findmessage);
            return RedirectToAction("Index","Contact");
        }
        public IActionResult getmessage(int id)
        {    
            var findmessage= mm.TGetById(id);
            return View(findmessage);
        }
    }
}
