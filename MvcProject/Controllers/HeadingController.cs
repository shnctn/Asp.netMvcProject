using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccess.EntityFramework;
using EntityLayer.Concrete;

namespace MvcProject.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading
        private HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var hmvalues= hm.GetList();
            return View(hmvalues);
        }



        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                select new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.CategoryId.ToString()
                }).ToList();
            List<SelectListItem> valueWriter = (from x in wm.GetList()
                select new SelectListItem
                {
                    Text = x.WriterName + " " + x.Surname,
                    Value = x.WriterId.ToString()
                }).ToList();
            ViewBag.vlc = valueCategory;
            ViewBag.vlr = valueWriter;
            return View();

        }
        [HttpPost]
        public ActionResult AddHeading(Heading h)
        {
            h.HeadingDate = DateTime.Parse(DateTime.Now.ToLongDateString());
            hm.HeadingAdd(h);
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }

        public ActionResult deleteHeading(int id)
        {
            var headingValue = hm.GetById(id);
            headingValue.HeadingStatus = false;
            hm.HeadingDelete(headingValue);
            return RedirectToAction("Index");
            
        }
    }
}