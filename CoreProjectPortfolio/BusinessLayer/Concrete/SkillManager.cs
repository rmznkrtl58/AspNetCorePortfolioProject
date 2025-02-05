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
    public class SkillManager : ISkillService
    {
        ISkillDal _skilldal;

        public SkillManager(ISkillDal skilldal)
        {
            _skilldal = skilldal;
        }

        public List<Skill> GetListByFilter(string p)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Skill t)
        {
            _skilldal.Insert(t);
        }

        public Skill TGetById(int id)
        {
           return _skilldal.GetById(id);
        }

        public List<Skill> TGetList()
        {
            return _skilldal.GetList();
        }

        public void TRemove(Skill t)
        {
            _skilldal.Delete(t);
        }

        public void TUpdate(Skill t)
        {
            _skilldal.Update(t);
        }
    }
}
