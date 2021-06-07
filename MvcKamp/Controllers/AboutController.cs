using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;

namespace MvcKamp.Controllers
{
    public class AboutController : Controller
    {
        private AboutManager Abm { get; } = new AboutManager(new EfAboutDal());

        public ActionResult Index()
        {
            var aboutValues = Abm.GetList();
            return View(aboutValues);
        }

        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            Abm.AboutAdd(about);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartialAdd()
        {
            return PartialView();
        }
    }
}