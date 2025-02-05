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
    public class ExperienceManager : IExperienceService
    {
        IExperienceDal _experiencedal;

        public ExperienceManager(IExperienceDal experiencedal)
        {
            _experiencedal = experiencedal;
        }

        public List<Experience> GetListByFilter(string p)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Experience t)
        {
            _experiencedal.Insert(t);
        }

        public Experience TGetById(int id)
        {
            return _experiencedal.GetById(id);
        }

        public List<Experience> TGetList()
        {
            return _experiencedal.GetList();
        }

        public void TRemove(Experience t)
        {
            _experiencedal.Delete(t);
        }

        public void TUpdate(Experience t)
        {
            _experiencedal.Update(t);
        }
    }
}
