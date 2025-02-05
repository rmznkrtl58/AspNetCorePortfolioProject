using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TodolistManager : ITodolistService
    {
        ITodolistDal _Itodolistdal;

        public TodolistManager(ITodolistDal ıtodolistdal)
        {
            _Itodolistdal = ıtodolistdal;
        }

        public List<ToDoList> GetListByFilter(string p)
        {
            throw new NotImplementedException();
        }

        public void TAdd(ToDoList t)
        {
            _Itodolistdal.Insert(t);
        }

        public ToDoList TGetById(int id)
        {
          return  _Itodolistdal.GetById(id);
        }

        public List<ToDoList> TGetList()
        {
            return _Itodolistdal.GetList();
        }

        public void TRemove(ToDoList t)
        {
            _Itodolistdal.Delete(t);
        }

        public void TUpdate(ToDoList t)
        {
            _Itodolistdal.Update(t);
        }
    }
}
