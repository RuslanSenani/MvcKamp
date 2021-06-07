using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete.Repositories;
using EntityLayer.Concrete;

namespace DataAccesLayer.EntityFramework
{
   public class EfMessageDal:GenericRepository<Message>,IMessageDal
    {
    }
}
