using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;

namespace MvcKamp.Controllers
{
    public class HeadingController : Controller
    {
        private readonly HeadingManager _hm = new HeadingManager(new EfHeadingDal());
        private readonly CategoryManager _cm = new CategoryManager(new EfCategoryDal());
        private readonly WriterManager _wr = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var hedingValue = _hm.GetList();
            return View(hedingValue);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> category = (from x in _cm.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryId.ToString()
                                             }).ToList();

            List<SelectListItem> writer = (from x in _wr.GetList()
                                           select new SelectListItem
                                           {
                                               Text = x.WriterName + @" " + x.WriterSurName,
                                               Value = x.WriterId.ToString()
                                           }).ToList();

            ViewBag.vlc = category;
            ViewBag.vlw = writer;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            _hm.HeadingAdd(heading);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> category = (from x in _cm.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryId.ToString()
                                             }).ToList();
            ViewBag.vlc = category;
            var headingValue = _hm.GetById(id);
            return View(headingValue);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            _hm.HeadingUpdate(heading);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {

            var headingValue = _hm.GetById(id);
            headingValue.HeadingStatus = false;
            _hm.HeadingDelete(headingValue);
            return RedirectToAction("Index");
        }
    }
}