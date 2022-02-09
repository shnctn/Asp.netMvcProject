using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using EntityLayer.Concrete;

namespace MvcProject.Controllers
{
    public class WriterPanelController : Controller
    {
        private CategoryManager cm = new CategoryManager(new EfCategoryDal());
        private HeadingManager hm = new HeadingManager(new EfHeadingDal());
        Context c = new Context();

        // GET: WriterPanel
        public ActionResult WriterProfile()
        {
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

        public ActionResult deleteHeading(int id)
        {
            var headingValue = hm.GetById(id);
            headingValue.HeadingStatus = false;
            hm.HeadingDelete(headingValue);
            return RedirectToAction("MyHeading");

        }
    }
}