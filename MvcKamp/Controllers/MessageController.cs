using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;

namespace MvcKamp.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        private readonly MessageManager _mm = new MessageManager(new EfMessageDal());
        private readonly MessageValidator _validations = new MessageValidator();
        [Authorize]
        public ActionResult Inbox()
        {
            var messageList = _mm.GetListInbox();
            return View(messageList);
        }

        public ActionResult SendBox()
        {
            var messageList = _mm.GetListSendbox();
            return View(messageList);
        }
        public ActionResult GetInBoxMessageDetails(int id)
        {
            var values = _mm.GetById(id);
            return View(values);
        }
        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var values = _mm.GetById(id);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult NewMessage(Message message)
        {
            ValidationResult result = _validations.Validate(message);
            if (result.IsValid)
            {
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                _mm.MessageAdd(message);
                return RedirectToAction("SendBox");
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