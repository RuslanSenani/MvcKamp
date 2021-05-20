using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;

namespace DataAccesLayer.Concrete.Repositories
{
    public class CategoryRepository:ICategoryDal
    {
        private readonly Context _c = new Context();
        private readonly DbSet<Category> _object;

        public CategoryRepository(DbSet<Category> o)
        {
            _object = o;
        }


        public List<Category> List()
        {
            return _object.ToList();
        }

        public void Insert(Category category)
        {
            _object.Add(category);
            _c.SaveChanges();
        }

        public void Update(Category category)
        {
            _c.SaveChanges();
        }

        public void Delete(Category category)
        {
            _object.Remove(category);
            _c.SaveChanges();
        }

        public List<Category> List(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
