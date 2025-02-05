using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CoreProjectPortfolio.Controllers
{
    public class AdminMessageController : Controller
    {
        WriterMessageManager wmm = new WriterMessageManager(new EfWriterMessageDal());
       
        public IActionResult senderbox()
        {   //Gönderilen mesajların listesi
            string p = "rmznkrtl@gmail.com";
            var messagelist = wmm.TGetListBySenderMessage(p);
            return View(messagelist);
        }
        public IActionResult receiverbox()
        {   //Gelen mesajların listesi
            string p = "rmznkrtl@gmail.com";
            var messagelist = wmm.TGetListByRecevierMessage(p);
            return View(messagelist);
        }
        public IActionResult Getsenderdetails(int id)
        {
            var findmessage = wmm.TGetById(id);
            return View(findmessage);
        }
        public IActionResult getdetails(int id)
        {
            var findmessage = wmm.TGetById(id);
            return View(findmessage);
        }
        //Adminin kayıt olan kullanıcılara mesaj gönderme işlemi
        [HttpGet]
        public IActionResult sendmessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult sendmessage(WriterMessage w)
        {
            w.SenderName = "Admin";
            w.Sender = "rmznkrtl@gmail.com";
            w.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            var ent = new Context();
            w.ReceiverName = ent.Users.Where(x => x.Email == w.Receiver).Select(x => x.Name + " " + x.Surname).FirstOrDefault();
            wmm.TAdd(w);
            return RedirectToAction("senderbox","AdminMessage");
        }
    }
}
