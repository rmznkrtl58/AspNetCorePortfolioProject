using EntityLayer.Concrete;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterMessageService:IGenericService<WriterMessage>
    {   //sisteme authontice olan kişinin gönderdiği mesajlar
        public List<WriterMessage> TGetListBySenderMessage(string p);
        //sisteme authontice olan kişiye Gönderilen mesajlardır;
        public List<WriterMessage> TGetListByRecevierMessage(string p);

      
    }
}
