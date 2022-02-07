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
    public class CategoryManager: ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

       public List<Category> GetList()
       {
           return _categoryDal.List();
       }

       public void CategoryAdd(Category c)
        {
            _categoryDal.insert(c);
        }

       public Category GetById(int id)
       {
           return _categoryDal.Get(x=>x.CategoryId==id);
       }

       public void CategoryDelete(Category c)
       {
           _categoryDal.Delete(c);
       }

       public void CategoryUpdate(Category c)
       {
           _categoryDal.Update(c);
       }
    }
}
