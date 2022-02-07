using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IMessageService 
    {
        List<Message> GetListInbox();
        List<Message> GetListSendbox();

        void MessageAdd(Message c);
        Message GetById(int id);
        void MessageDelete(Message c);
        void MessageUpdate(Message c);
    }
}
