using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using EntityLayer.Concrete;

namespace MvcProject.Controllers
{  
    public class AboutController : Controller
    {
      
        private AboutManager abm = new AboutManager(new EfAboutDal());
        // GET: About
        public ActionResult Index()
        {
            var aboutvalues = abm.GetList();
            return View(aboutvalues);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {

            return View();
        }


        [HttpPost]
        public ActionResult AddAbout(About a)
        {
          abm.AboutAdd(a);
          return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
    }
}