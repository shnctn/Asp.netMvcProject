﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;
using EntityLayer;

namespace DataAccess.EntityFramework
{
    public class EfContentDal:GenericRepository<Content>,IContentDal
    {
    }
}