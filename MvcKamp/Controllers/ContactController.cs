using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.EntityFramework;

namespace MvcKamp.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        private readonly ContactManager _cm = new ContactManager(new EfContactDal());
        private readonly ContactValidator _validator = new ContactValidator();
        public ActionResult Index()
        {
            var contactValue = _cm.GetList();
            return View(contactValue);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactValues = _cm.GetById(id);
            return View(contactValues);
        }

        public PartialViewResult ContactPartialMenu()
        {
            return PartialView();
        }

        public PartialViewResult ContentPartialHeader()
        {
            return PartialView();
        }
    }
}