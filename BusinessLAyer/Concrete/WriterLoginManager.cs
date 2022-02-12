using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccess.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
     public class WriterLoginManager:IWriterLoginService
     {
         private IWriterDal _writerDal;

         public WriterLoginManager(IWriterDal writerDal)
         {
             _writerDal = writerDal;
         }

         public Writer GetWriter(string Username, string Password)
         {
             return _writerDal.Get(x => x.WriterMail == Username && x.WriterPassword == Password);
         }
    }
}
