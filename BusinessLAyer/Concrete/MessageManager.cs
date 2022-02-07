﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccess.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
   public  class MessageManager:IMessageService
   {
       private IMessageDal _messageDal;

       public MessageManager(IMessageDal messageDal)
       {
           _messageDal = messageDal;
       }

       public List<Message> GetListInbox()
       {
           return _messageDal.List(x=>x.ReceiverMail=="admin@gmail.com");
       }

        public List<Message> GetListSendbox()
       {
          return _messageDal.List(x => x.SenderMail == "admin@gmail.com");
        }

       public void MessageAdd(Message c)
       {
          _messageDal.insert(c);
       }

       public Message GetById(int id)
       {
          return _messageDal.Get(x => x.Id == id);
       }

       public void MessageDelete(Message c)
       {
           _messageDal.Delete(c);
       }

       public void MessageUpdate(Message c)
       {
          _messageDal.Update(c);

       }
   }

   
}