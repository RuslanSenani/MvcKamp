using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
   public interface ICategoryService
   {
       List<Category> GetList();
       void CategoryAdd(Category pCategory);

       Category GetById(int id);
       void CategoryDelete(Category category);
       void CategoryUpdate(Category category);
       


   }
}
