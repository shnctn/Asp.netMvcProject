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
    public class HeadingManager:IHeadingService
    {
        private IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public List<Heading> GetList()
        {
            return _headingDal.List();
        }

        public void HeadingAdd(Heading h)
        {
           _headingDal.insert(h);
        }

        public Heading GetById(int id)
        {
           return _headingDal.Get(x=>x.HeadingId==id);
        }

        public void HeadingDelete(Heading h)
        {
            
           _headingDal.Update(h);
        }

        public void HeadingUpdate(Heading h)
        {
          _headingDal.Update(h);
        }
    }
}
