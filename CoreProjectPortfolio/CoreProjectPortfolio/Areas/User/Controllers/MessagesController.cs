using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CoreProjectPortfolio.Areas.User.Controllers
{   
    
    //1.metod:id'parametresini alamayıp mesaj detaylarını göremediğimiz
    //için çözümü için ilk adımı böyle attık
    [Area("User")]          
    [Route("User/Messages")]  //->kullanımı Area/ilgili Kontrollerin ismi
    public class MessagesController : Controller
    {
        WriterMessageManager wm = new WriterMessageManager(new EfWriterMessageDal());
        private readonly UserManager<WriterUser> _usermanager;

        public MessagesController(UserManager<WriterUser> usermanager)
        {
            _usermanager = usermanager;
        }
        //SenderMessage
        [Route("")]
        [Route("Index")]//2.metod:açılmasını istediğim sayfalara bu iki route tanımlamalarımı yapıyorum
        public async Task<IActionResult> Index(string p)
        {   //sisteme authontice olmuş birinin gönderdiği
            //mesajların listelendiği yerdir.
            var finduser = await _usermanager.FindByNameAsync(User.Identity.Name);
            p = finduser.Email;
            var receviermessagelist = wm.TGetListBySenderMessage(p);
            return View(receviermessagelist);
        }
        //ReceiverMessage
        [Route("")]
        [Route("Receivermessage")]//2.metod:açılmasını istediğim sayfalara bu iki route tanımlamalarımı yapıyorum
        public async Task<IActionResult> Receivermessage(string p)
        {
            //sisteme authontice olmuş birine gelen
            //mesajların listelendiği yerdir.
            var finduser = await _usermanager.FindByNameAsync(User.Identity.Name);
            p=finduser.Email;
            var receivermessagelist=wm.TGetListByRecevierMessage(p);
            return View(receivermessagelist);
        }
        //3.metod:id parametreli sayfalarıma yönlendirme yaparken id
        //route ayarını ilgili action/{id} diye tanımlarız
        [Route("Getsendermessagedetails/{id}")]
        public IActionResult Getsendermessagedetails(int id)
        {
            WriterMessage messagedetails = wm.TGetById(id);
            return View(messagedetails);
        }
        [Route("Getreceiverdetails/{id}")]
        public IActionResult Getreceiverdetails(int id)
        {   
            WriterMessage messagedetails=wm.TGetById(id);
            return View(messagedetails);
        }
        [HttpGet]
        [Route("")]
        [Route("Addmessage")]
        public IActionResult Addmessage()
        {
            return View();
        }
        [HttpPost]
        [Route("")]
        [Route("Addmessage")]
        public async Task<IActionResult> Addmessage(WriterMessage p)
        {   //authontice olan kullanıcının birisine mesaj yollama işlemi
            var finduser = await _usermanager.FindByNameAsync(User.Identity.Name);
            p.Sender = finduser.Email;
            p.SenderName = finduser.Name + " " + finduser.Surname;
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            var ent = new Context();
            //alıcı mailinin mesaj gönderme işleminde yazıyorduk fakat alıcı isim ve soyisminide aynı
            //mail üzerinden çekebilmek için alttaki sorguyu yazdık 
            //ent.users->users benim sqldeki aspnetusers tabloma göre hareket eder 
            //where diyip gerekli şartı yazdım işte->aspnetusert tablosundaki mailler arasında
            //benim sayfamda göndereceğim alıcı mailine eşit olan tablomdaki satırın içerisinden
            //name ve surname değerlerini seç ve getir bana
            p.ReceiverName = ent.Users.Where(x => x.Email == p.Receiver).Select(x => x.Name + " " + x.Surname).FirstOrDefault();
            wm.TAdd(p);
            return RedirectToAction("Index","Messages");
        }
    }
}
