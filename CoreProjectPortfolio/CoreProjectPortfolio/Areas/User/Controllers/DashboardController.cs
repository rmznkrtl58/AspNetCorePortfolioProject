using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CoreProjectPortfolio.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/[controller]/[action]")]
    public class DashboardController : Controller
    {
        private readonly UserManager<WriterUser> _usermanager;

        public DashboardController(UserManager<WriterUser> usermanager)
        {
            _usermanager = usermanager;
        }

        public async Task<IActionResult> Index()
        {   Context ent = new Context();
            var values = await _usermanager.FindByNameAsync(User.Identity.Name);
            ViewBag.data = values.Name + " " + values.Surname;
            ViewBag.d1 = ent.WriterMessages.Where(x => x.Receiver == values.Email).Count();
            ViewBag.d2 = ent.Announcements.Count();
            ViewBag.d3=ent.Users.Count();
            ViewBag.d4=ent.Skills.Count();
            //Weather
            string api ="8e6e75be646275947f8163ddfa3be7cf";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid="+ api;
            XDocument document =XDocument.Load(connection);
            ViewBag.w=document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
        }
    }
}
//
