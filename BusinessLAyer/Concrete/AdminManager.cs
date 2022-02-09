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
   public  class AdminManager:IAdminService
   {
       private IAdminDal _adminDal;

       public AdminManager(IAdminDal adminDal)
       {
           _adminDal = adminDal;
       }

       public List<Admin> GetList()
       {
           return _adminDal.List();
       }

        public void AdminAdd(Admin c)
        {
            _adminDal.insert(c);
        }

        public Admin GetById(int id)
        {
          return  _adminDal.Get(x => x.AdminId == id);
        }

        public void AdminDelete(Admin c)
        {
           _adminDal.Delete(c);
        }

        public void AdminUpdate(Admin c)
        {
            _adminDal.Update(c);
        }
    }
}
