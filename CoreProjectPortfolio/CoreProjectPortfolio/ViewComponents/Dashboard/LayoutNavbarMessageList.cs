using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreProjectPortfolio.ViewComponents.Dashboard
{
    public class LayoutNavbarMessageList:ViewComponent
    {
        WriterMessageManager wm = new WriterMessageManager(new EfWriterMessageDal());
        public IViewComponentResult Invoke()
        {
            var Messagelist = wm.TGetListByRecevierMessage("rmznkrtl@gmail.com");
            var messagecount = wm.TGetListByRecevierMessage("rmznkrtl@gmail.com").ToList().Count();
            //admine mesaj atanların maillerini seçtim
            var p= wm.TGetListByRecevierMessage("rmznkrtl@gmail.com").Select(x=>x.Sender).ToList();
            var ent = new Context();
            //var userımage=ent.Users.Where(x=>x.Email==p)
            ViewBag.m = messagecount;
            return View(Messagelist);
        }
    }
}
