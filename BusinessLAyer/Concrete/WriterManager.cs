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
     public class WriterManager:IWriterService
     {
         private IWriterDal _writerDal;

         public WriterManager(IWriterDal writerDal)
         {
             _writerDal = writerDal;
         }

         public List<Writer> getList()
         {
           return  _writerDal.List();
         }

        public void WriterAdd(Writer r)
        {
            _writerDal.insert(r);
        }

        public void WriterDelete(Writer r)
        {
            _writerDal.Delete(r);
        }

        public void WriterUpdate(Writer r)
        {
            _writerDal.Update(r);
        }

        public Writer GetById(int id)
        {
            return _writerDal.Get(x => x.WriterId == id);
        }
    }
}
