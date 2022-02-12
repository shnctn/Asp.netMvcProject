using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using PagedList.Mvc;

namespace MvcProject.Controllers
{
    public class WriterPanelController : Controller
    {
        private CategoryManager cm = new CategoryManager(new EfCategoryDal());
        private HeadingManager hm = new HeadingManager(new EfHeadingDal());
        WriterValidatior writerValidatior = new WriterValidatior();
        private WriterManager wm = new WriterManager(new EfWriterDal());
        Context c = new Context();

        // GET: WriterPanel
        [HttpGet]
        public ActionResult WriterProfile(int id=0)
        {
            string p = (string)Session["WriterMail"];
            ViewBag.d = p;
            id = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
            var writervalue = wm.GetById(id);
            return View(writervalue);
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer r)
        {
            ValidationResult result = writerValidatior.Validate(r);
            if (result.IsValid)
            {
                wm.WriterUpdate(r);
                return RedirectToAction("AllHeading","WriterPanel");
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
        public ActionResult MyHeading(string p)
        {
           
            p = (string) Session["WriterMail"];
             var writeridinfo = c.Writers.Where(x=>x.WriterMail==p).Select(y=>y.WriterId).FirstOrDefault();
            var values = hm.GetListByWriter(writeridinfo);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                select new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.CategoryId.ToString()
                }).ToList();
            ViewBag.vlc = valueCategory;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading h)
        {
            string writermailinfo = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == writermailinfo).Select(y => y.WriterId).FirstOrDefault();
            h.HeadingDate = DateTime.Parse(DateTime.Now.ToLongDateString());
            h.WriterId = writeridinfo;
            h.HeadingStatus = true;
            hm.HeadingAdd(h);

            return RedirectToAction("MyHeading");
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                select new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.CategoryId.ToString()
                }).ToList();
            ViewBag.vlc = valueCategory;
            var headingValue = hm.GetById(id);
            return View(headingValue);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading h)
        {
            hm.HeadingUpdate(h);
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValue = hm.GetById(id);
            headingValue.HeadingStatus = false;
            hm.HeadingDelete(headingValue);
            return RedirectToAction("MyHeading");

        }

        public ActionResult AllHeading(int p=1)
        {
            var headings = hm.GetList().ToPagedList(p, 6);
            return View(headings);
        }

      
    }
}