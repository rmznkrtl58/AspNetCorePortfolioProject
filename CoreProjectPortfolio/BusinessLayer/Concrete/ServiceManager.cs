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
    public class ServiceManager : IServicesService
    {
        IServiceDal _servicedal;

        public ServiceManager(IServiceDal servicedal)
        {
            _servicedal = servicedal;
        }

        public List<Service> GetListByFilter(string p)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Service t)
        {
            _servicedal.Insert(t);
        }

        public Service TGetById(int id)
        {
          return  _servicedal.GetById(id);
        }

        public List<Service> TGetList()
        {
           return _servicedal.GetList();
        }

        public void TRemove(Service t)
        {
            _servicedal.Delete(t);
        }

        public void TUpdate(Service t)
        {
            _servicedal.Update(t);
        }
    }
}
