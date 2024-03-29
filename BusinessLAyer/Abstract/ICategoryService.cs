﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetList();

        void CategoryAdd(Category c);
        Category GetById(int id);
        void CategoryDelete(Category c);
        void CategoryUpdate(Category c);

    }
}
