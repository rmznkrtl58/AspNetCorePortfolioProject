using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjectPortfolio.ViewComponents.Experience
{
    public class ExperienceList:ViewComponent
    {
        ExperienceManager em = new ExperienceManager(new EFExperienceDal());
        public IViewComponentResult Invoke()
        {
            var values = em.TGetList();
            return View(values);
        }
    }
}
