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
   public class AboutManager:IAboutService
   {
       private IAboutDal _aboutDal;

       public AboutManager(IAboutDal aboutDal)
       {
           _aboutDal = aboutDal;
       }

       public List<About> GetList()
       {
           return _aboutDal.List();
       }

       public void AboutAdd(About a)
       {
           _aboutDal.insert(a);
       }

        public About GetById(int id)
        {
            return _aboutDal.Get(x => x.AboutId == id);
        }

        public void AboutDelete(About a)
        {
            _aboutDal.Delete(a);
        }

        public void AboutUpdate(About a)
        {
            _aboutDal.Update(a);
        }
    }
}
