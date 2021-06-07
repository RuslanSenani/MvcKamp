using System.Collections.Generic;
using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
   public class ContentManager:IContentService
   {
       private readonly IContentDal _contentDal;

       public ContentManager(IContentDal contentDal)
       {
           _contentDal = contentDal;
       }

       public List<Content> GetList()
       {
          return _contentDal.List();
       }

       public List<Content> GetListByHeadingId(int id)
       {
           return _contentDal.List(x => x.HeadingId == id);
       }

       public void ContentAdd(Content content)
        {
            _contentDal.Insert(content);
        }

        public Content GetById(int id)
        {
            return _contentDal.Get(x => x.ContentId == id);
        }

        public void ContentDelete(Content content)
        {
            _contentDal.Delete(content);
        }

        public void ContentUpdate(Content content)
        {
            _contentDal.Update(content);
        }
    }
}
