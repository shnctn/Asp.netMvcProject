using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccess.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;

namespace MvcProject.Controllers
{
    public class MessageController : Controller
    {
        private MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();

        // GET: Message
        public ActionResult Inbox()
        {
            var messagevalue = mm.GetListInbox();
            return View(messagevalue);
        }

        public ActionResult Sendbox()
        {
            var messagevalue = mm.GetListSendbox();
            return View(messagevalue);
        }
        [HttpGet]
        public ActionResult GetInboxDetails(int id)
        {
            var values = mm.GetById(id);
            return View(values);
        }
        [HttpGet]
        public ActionResult GetSendboxDetails(int id)
        {
            var values = mm.GetById(id);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message m)
        {

            ValidationResult result = messageValidator.Validate(m);
            if (result.IsValid)
            {
                m.MessageDate=DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAdd(m);
                return RedirectToAction("Sendbox");
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