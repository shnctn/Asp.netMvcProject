﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;
using EntityLayer.Concrete;

namespace DataAccess.EntityFramework
{
    public class EfWriterDal:GenericRepository<Writer>, IWriterDal
    {
    }
}
