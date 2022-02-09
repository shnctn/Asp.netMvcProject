using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        List<Admin> GetList();

        void AdminAdd(Admin c);
        Admin GetById(int id);
        void AdminDelete(Admin c);
        void AdminUpdate(Admin c);
    }
}
