using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
     public interface IHeadingService
    {
        List<Heading> GetList();

        void HeadingAdd(Heading h);
        Heading GetById(int id);
        void HeadingDelete(Heading h);
        void HeadingUpdate(Heading h);

    }
}
