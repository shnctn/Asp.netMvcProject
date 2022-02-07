using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IContactServise

    {
        List<Contact> GetList();

        void ContactAdd(Contact c);
        Contact GetById(int id);
        void ContactDelete(Contact c);
        void ContactUpdate(Contact c);
    }
}
