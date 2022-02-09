using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;

namespace DataAccess.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T:class
    {
        private readonly Context con = new Context();
        private readonly DbSet<T> _object;

        public GenericRepository()
        {
            _object = con.Set<T>();

        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public void insert(T t)
        {
            var addedEntity = con.Entry(t);
            addedEntity.State = EntityState.Added;
           // _object.Add(t);
            con.SaveChanges();
        }

        public void Update(T t)
        {
            var updatedEntity = con.Entry(t);
            updatedEntity.State = EntityState.Modified;
            con.SaveChanges();
        }

        public void Delete(T t)
        {
            var deletedEntity = con.Entry(t);
            deletedEntity.State = EntityState.Deleted;
            //_object.Remove(t);
            con.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);  // dizide  tek bir deger döndürler komut singledefault
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }
    }
}
