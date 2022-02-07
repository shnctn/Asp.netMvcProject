using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class ContactManger:IContactServise
    {
        private IContactDal _contactDal;

        public ContactManger(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public List<Contact> GetList()
        {
            return _contactDal.List();
        }

        public void ContactAdd(Contact c)
        {
            _contactDal.insert(c);
        }

        public Contact GetById(int id)
        {
           return  _contactDal.Get(x => x.ContactID == id);
        }

        public void ContactDelete(Contact c)
        {
          _contactDal.Delete(c);
        }

        public void ContactUpdate(Contact c)
        {
            _contactDal.Update(c);
        }
    }
}
