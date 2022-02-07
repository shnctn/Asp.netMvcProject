using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
   public interface IAboutService
    {
        List<About> GetList();

        void AboutAdd(About a);
        About GetById(int id);
        void AboutDelete(About a);
        void AboutUpdate(About a);
    }
}
