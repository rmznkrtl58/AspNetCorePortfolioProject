using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoreProjectPortfolio.Controllers
{   
	public class Default : Controller
	{   //LAYOUT SAYFAM
		public IActionResult Index()
		{
			return View();
		}
		public PartialViewResult HeadPartail()
		{
			return PartialView();
		}
		public PartialViewResult NavbarPartial()
		{
			return PartialView();
		}
		[HttpGet]
		public PartialViewResult SendMessage()
		{
			return PartialView();
		}
        [HttpPost]
        public PartialViewResult SendMessage(Message m)
        {
			ContactMessageManager cmm = new ContactMessageManager(new EFMessageDal());
			m.Status = true;
			m.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
			cmm.TAdd(m);
            return PartialView();
        }
    }
}
