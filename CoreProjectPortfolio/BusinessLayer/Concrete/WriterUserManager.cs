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
    public class WriterUserManager : IWriterUserService
    {
        IWriterUserDal _writeruser;

        public WriterUserManager(IWriterUserDal writeruser)
        {
            _writeruser = writeruser;
        }

        public List<WriterUser> GetListByFilter(string p)
        {
            throw new NotImplementedException();
        }

        public void TAdd(WriterUser t)
        {
            _writeruser.Insert(t);
        }

        public WriterUser TGetById(int id)
        {
          return _writeruser.GetById(id);
        }

        public List<WriterUser> TGetList()
        {
            return _writeruser.GetList();
        }

        public void TRemove(WriterUser t)
        {
            _writeruser.Delete(t);
        }

        public void TUpdate(WriterUser t)
        {
            _writeruser.Update(t);
        }
    }
}
