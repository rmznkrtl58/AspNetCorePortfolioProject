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
   public class FeatureManager : IGenericService<Feature>
    {
        IFeaturedDal _featuredal;

        public FeatureManager(IFeaturedDal featuredal)
        {
            _featuredal = featuredal;
        }

        public List<Feature> GetListByFilter(string p)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Feature t)
        {
            _featuredal.Insert(t);
        }

        public Feature TGetById(int id)
        {
            return _featuredal.GetById(id);
        }

        public List<Feature> TGetList()
        {
            return _featuredal.GetList();
        }

        public void TRemove(Feature t)
        {
            _featuredal.Delete(t);
        }

        public void TUpdate(Feature t)
        {
            _featuredal.Update(t);
        }
    }
}
