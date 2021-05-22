using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using DataAccesLayer.Concrete;
using EntityLayer.Concrete;

namespace MvcKamp.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly Context _context = new Context();
        public ActionResult Index()
        {
            ViewBag.WriterCount = _context.Writers.Count(x => x.WriterName.Contains("a"));
            ViewBag.CategoryCount = _context.Categories.Count();
            ViewBag.HeadingCategory = _context.Categories.Join(_context.Headings, category => category.CategoryId,
                heading => heading.CategoryId, (ca, he) => new
                {
                    categoty = ca,
                    heading = he
                }).Count(x => x.categoty.CategoryName.Contains("Developer"));
            return View();
        }
    }
}