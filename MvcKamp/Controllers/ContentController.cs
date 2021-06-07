using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;

namespace MvcKamp.Controllers
{
    public class ContentController : Controller
    {
        private readonly ContentManager _cm = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ContentByHeading(int id)
        {
            var contentValue = _cm.GetListByHeadingId(id);
            return View(contentValue);
        }
    }
}