﻿using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void CategoryAdd(Category pCategory)
        {
           _categoryDal.Insert(pCategory);
        }

        public void CategoryDelete(Category category)
        {
             _categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }

        public Category GetById(int id)
        {

            return _categoryDal.Get(x => x.CategoryId == id);
        }

        public List<Category> GetList()
        {
            return _categoryDal.List();
        }

        
    }

}