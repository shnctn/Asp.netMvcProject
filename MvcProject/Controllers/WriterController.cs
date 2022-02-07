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
    public class WriterController : Controller
    {
        // GET: Writer
        private WriterManager wm = new WriterManager(new EfWriterDal()); 
        WriterValidatior writerValidatior = new WriterValidatior();
        public ActionResult Index()
        {
            var Writervalues = wm.getList();

            return View(Writervalues);
        }

        [HttpGet]
        public ActionResult Addwriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Addwriter(Writer r)
        {
          
            ValidationResult result = writerValidatior.Validate(r);
            if (result.IsValid)
            {
                wm.WriterAdd(r);
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
            var writervalue = wm.GetById(id);

            return View(writervalue);
        }

        [HttpPost]
        public ActionResult EditWriter(Writer r)
        {
            ValidationResult result = writerValidatior.Validate(r);
            if (result.IsValid)
            {
                wm.WriterUpdate(r);
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