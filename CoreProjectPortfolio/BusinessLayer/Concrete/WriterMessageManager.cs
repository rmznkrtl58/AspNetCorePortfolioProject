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
    public class WriterMessageManager : IWriterMessageService
    {
        IWriterMessageDal _writermessagedal;

        public WriterMessageManager(IWriterMessageDal writermessagedal)
        {
            _writermessagedal = writermessagedal;
        }
        public List<WriterMessage> GetListByFilter(string p)
        {
            //alıcısı p parametresine eşit olan mesajları listele
            throw new NotImplementedException();
        }
        public void TAdd(WriterMessage t)
        {
            _writermessagedal.Insert(t);
        }

        public WriterMessage TGetById(int id)
        {
           return _writermessagedal.GetById(id);
        }

        public List<WriterMessage> TGetList()
        {
            return _writermessagedal.GetList();
        }

        public List<WriterMessage> TGetListByRecevierMessage(string p)
        {
            return _writermessagedal.GetByFilter(x => x.Receiver == p);
        }

        public List<WriterMessage> TGetListBySenderMessage(string p)
        {
          return  _writermessagedal.GetByFilter(x => x.Sender == p);
        }

        public void TRemove(WriterMessage t)
        {
            _writermessagedal.Delete(t);
        }

        public void TUpdate(WriterMessage t)
        {
            _writermessagedal.Update(t);
        }

       
    }
}
