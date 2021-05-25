using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;

namespace MvcKamp.Controllers
{
    public class WriterController : Controller
    {
        private readonly WriterManager _wm = new WriterManager(new EfWriterDal());
        private readonly WriterValidator writerValidator = new WriterValidator();
        public ActionResult Index()
        {
            var writerValues = _wm.GetList();
            return View(writerValues);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(Writer writer)
        {

            ValidationResult result = writerValidator.Validate(writer);
            if (result.IsValid)
            {
                _wm.WriterAdd(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }

        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var writerValue = _wm.GetById(id);
            return View(writerValue);
        }

        [HttpPost]
        public ActionResult EditWriter(Writer writer)
        {
            ValidationResult result = writerValidator.Validate(writer);
            if (result.IsValid)
            {
                _wm.WriterUpdate(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }



    }
}