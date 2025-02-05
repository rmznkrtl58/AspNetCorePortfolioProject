using Core_Proje_Api.Dal.ApiContext;
using Core_Proje_Api.Dal.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Proje_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //apileri sweggar üzerinden kullandığımız alan
    public class CategoryController : ControllerBase
    {   
        [HttpGet]
        public IActionResult GetCategoryList()
        {
            using var ent = new Context();
            return Ok(ent.Categories.ToList());//OK->Apilerde sonucun başarılı olduğunu gösteren metod
        }
        [HttpGet("{id}")]//id'ye göre getirmek istediğimiz için id'yide burada kullanıyorum
        public IActionResult CategoryById(int id)
        {
            using var ent = new Context();
            var values = ent.Categories.Find(id);
            if (values == null)
            {
                return NotFound();//values değişkenim her hangi bir değer almadıysa hiç bir şey göstermesin
            }
            else
            {
                return Ok(values);
            }
        }
        [HttpPost]
        public IActionResult addcategory(Category c)
        {   
            using var ent = new Context();
            ent.Categories.Add(c);
            ent.SaveChanges();
            return Created("",c);
        }
        [HttpDelete]
        public IActionResult deletecategory(int id)
        {
            using var ent = new Context();
            var findcategory=ent.Categories.Find(id);
            if (findcategory == null)
            {
                return NotFound();
            }
            else
            {
                ent.Remove(findcategory);
                ent.SaveChanges();
                return NoContent();
            }
         
        }
        [HttpPut]//Güncellemede kullanıyoz
        public IActionResult updatecategory(Category c)
        {
            using var ent = new Context();
            //güncelleme işleminde bulma işlemi aşağıda yapılır
            var findcategory = ent.Find<Category>(c.CategoryId);
            if (findcategory == null)
            {
                return NotFound();
            }
            else
            {
                findcategory.CategoryName= c.CategoryName;
                ent.Update(findcategory);
                ent.SaveChanges();
                return NoContent();
            }
        }
    }
}
