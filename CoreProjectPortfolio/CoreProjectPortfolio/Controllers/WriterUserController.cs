using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreProjectPortfolio.Controllers
{
    public class WriterUserController : Controller
    {
        //Ajaxı örnekleriyle kullandığımız alandır.
        WriterUserManager wum = new WriterUserManager(new EfWriterUserDal());
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListUser()
        {
            //listelenecek değerler serializeobject metoduyla kullanılır
            //her hangi bir parametre veya id veya api gibi değerleri çağırdığımda 
            //deserializeobject metodu kullanılır
            //temel crudlardada kullanılabilir (serializeobject)
            var values = JsonConvert.SerializeObject(wum.TGetList());
            return Json(values);
        }
    }
}
