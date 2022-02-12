using System;
using System.Collections.Generic;
using BusinessLayer.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using System.Linq;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class WriterPanelContentController : Controller
    {
        Context c = new Context();
        private ContentManager cm = new ContentManager(new EfContentDal());
        private HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cgm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        // GET: WriterPanelContent
        public ActionResult MyContent(string p)
        {
            p = (string)Session["WriterMail"];
            var writeridınfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();

            var contentvalues = cm.GetListByWriterID(writeridınfo);
            return View(contentvalues);
        }

        [HttpGet]
        public ActionResult AddContent()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddContent(EntityLayer.Concrete.Content p)
        {
             p.ContentDate=DateTime.Now;
            cm.ContentAdd(p);
            return RedirectToAction("MyContent");
        }
       
       
       
        [HttpGet]
        public ActionResult EditContent(int id)
        {
            List<SelectListItem> valueHeading = (from x in hm.GetList()
                select new SelectListItem
                {
                    Text = x.HeadingName,
                    Value = x.HeadingId.ToString()
                }).ToList();
            ViewBag.vlc = valueHeading;
            var contentValue = cm.GetById(id);
            return View(contentValue);
        }

        [HttpPost]
        public ActionResult EditHeading(EntityLayer.Concrete.Content cn)
        {
            string mail = (string)Session["WriterMail"];
            var writeridınfo = c.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterId).FirstOrDefault();

            cn.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            cn.WriterId = writeridınfo;
            cn.ContentStatus = false;
            
            cm.ContentUpdate(cn);
            return RedirectToAction("MyContent");
        }
    }
}