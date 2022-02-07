using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccess.EntityFramework;

namespace MvcProject.Controllers
{
    public class ContactController : Controller
    {
        private ContactManger cm = new ContactManger(new EfContactDal());
        // GET: Contact
        public ActionResult Index()
        {
            var contactvalues = cm.GetList();
            return View(contactvalues);
        }
        [HttpGet]
        public ActionResult GetContactDetails(int id)
        {
            var contactvalues = cm.GetById(id);
            return View(contactvalues);
        }


        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
    }
}