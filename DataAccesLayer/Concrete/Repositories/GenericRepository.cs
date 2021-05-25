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
            var addEntity = _db.Entry(p);
            addEntity.State = EntityState.Added;
            _db.SaveChanges();
        }

        public void Update(T p)
        {
            var updateEntity = _db.Entry(p);
            updateEntity.State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(T p)
        {
            var deleteEntity = _db.Entry(p);
            deleteEntity.State = EntityState.Deleted;
            _db.SaveChanges();
            
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }
    }
}
