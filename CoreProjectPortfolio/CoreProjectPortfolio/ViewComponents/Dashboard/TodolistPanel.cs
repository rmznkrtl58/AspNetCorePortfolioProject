using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjectPortfolio.ViewComponents.Dashboard
{
    public class TodolistPanel:ViewComponent
    {
        TodolistManager tm = new TodolistManager(new EfTodolistDal());
        public IViewComponentResult Invoke()
        {
            var todolist = tm.TGetList();
            return View(todolist);
        }
    }
}
