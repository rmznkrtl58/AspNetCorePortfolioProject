using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{                //ctrl+"." consctructor metod tanımlaması
	public class AboutManager : IAboutService
	{
		IAboutDal _aboutdal;

        public AboutManager(IAboutDal aboutdal)
        {
            _aboutdal = aboutdal;
		}

        public List<About> GetListByFilter(string p)
        {
            throw new NotImplementedException();
        }

        //buradaki aboutdal parametreme,EfAboutDal
        //içerisine kalıtım olarak aldığım
        //GenericRepository<About>,IAboutDal
        //yolluyorum
        public void TAdd(About t)
		{
			_aboutdal.Insert(t);
		}

		public About TGetById(int id)
		{
			return _aboutdal.GetById(id);
		}

		public List<About> TGetList()
		{
			return _aboutdal.GetList();
		}

		public void TRemove(About t)
		{
			_aboutdal.Delete(t);
		}

		public void TUpdate(About t)
		{
			_aboutdal.Update(t);
		}
	}
}
