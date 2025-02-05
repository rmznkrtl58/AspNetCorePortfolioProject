using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreProjectPortfolio.Controllers
{
    public class Experience2Controller : Controller
    {   //Ajaxı örnekleriyle kullandığımız alandır.
        ExperienceManager em = new ExperienceManager(new EFExperienceDal());
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListExperience()
        {
            //listelenecek değerler serializeobject metoduyla kullanılır
            //her hangi bir parametre veya id veya api gibi değerleri çağırdığımda 
            //deserializeobject metodu kullanılır
            //temel crudlardada kullanılabilir (serializeobject)
            var values = JsonConvert.SerializeObject(em.TGetList());
            return Json(values);
        }
        [HttpPost]
        public IActionResult AddExperience(Experience e)
        {
            em.TAdd(e);
            var values=JsonConvert.SerializeObject(e);
            return Json(values);
        }
        public IActionResult GetExperienceById(int ExperienceId)//buradaki parametrenin aynen
                                                   //tablodaki adı olacak
        {
            var findvalues = em.TGetById(ExperienceId);
            var values = JsonConvert.SerializeObject(findvalues);
            return Json(values);
        }
        public IActionResult DeleteExperience(int id)
        {
            var findvalue= em.TGetById(id);
            em.TRemove(findvalue);
            return NoContent();//Ajaxta silme işlemi yapacağım için hiçbir şey dödürmesede olur
        }
    }
}
