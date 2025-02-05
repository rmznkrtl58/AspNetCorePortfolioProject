using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreProjectPortfolio.Areas.User.ViewComponents
{
    public class ProfileImage:ViewComponent
    {
        private readonly UserManager<WriterUser> _usermanager;

        public ProfileImage(UserManager<WriterUser> usermanager)
        {
            _usermanager = usermanager;
        }

        public async Task<IViewComponentResult> InvokeAsync()//InvokeAsync kullanmamızın sebebi
        {                                                    //Await bir işlem yaptığımız için 
            var finduser = await _usermanager.FindByNameAsync(User.Identity.Name);
            ViewBag.img=finduser.ImageUrl;
            return View();
        }
    }
}
