using Microsoft.AspNetCore.Mvc;

namespace CoreProjectPortfolio.ViewComponents.Contact
{
    public class SendMessage:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
