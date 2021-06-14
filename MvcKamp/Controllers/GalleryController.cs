using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;

namespace MvcKamp.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        private readonly ImageFileManager _ifm = new ImageFileManager(new EfImageFileDal());
        public ActionResult Index()
        {
            var files = _ifm.GetList();
            return View(files);
        }
    }
}