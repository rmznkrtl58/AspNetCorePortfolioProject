using Microsoft.AspNetCore.Mvc;

namespace CoreProjectPortfolio.ViewComponents.Dashboard
{
    public class Last5Projects:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
