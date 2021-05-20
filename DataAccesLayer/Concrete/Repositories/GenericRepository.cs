using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DataAccesLayer.Abstract;

namespace DataAccesLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        readonly Context _db = new Context();
        private readonly DbSet<T> _object;

        public GenericRepository()
        {
            _object = _db.Set<T>();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public void Insert(T p)
        {
            _object.Add(p);
            _db.SaveChanges();
        }

        public void Update(T p)
        {

            _db.SaveChanges();
        }

        public void Delete(T p)
        {
            _object.Remove(p);
            _db.SaveChanges();
            
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }
    }
}
