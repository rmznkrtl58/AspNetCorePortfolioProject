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
    public class AnnouncementManager : IAnnouncementService
    {
        IAnnouncementDal _IannouncementDal;

        public AnnouncementManager(IAnnouncementDal announcementDal)
        {
            _IannouncementDal = announcementDal;
        }

        public List<Announcement> GetListByFilter(string p)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Announcement t)
        {
            _IannouncementDal.Insert(t);
        }

        public Announcement TGetById(int id)
        {
            return _IannouncementDal.GetById(id);
        }

        public List<Announcement> TGetList()
        {
            return _IannouncementDal.GetList();
        }

        public void TRemove(Announcement t)
        {
           _IannouncementDal.Delete(t);
        }

        public void TUpdate(Announcement t)
        {
            _IannouncementDal.Update(t);
        }
    }
}
