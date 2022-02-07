using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
     public interface IRepository<T>
     {
         List<T> List();
         void insert(T t);
         void Update(T t);

         void Delete(T t);

         T Get(Expression<Func<T, bool>> filter);

         List<T> List(Expression<Func<T, bool>> filter);
     }
}
