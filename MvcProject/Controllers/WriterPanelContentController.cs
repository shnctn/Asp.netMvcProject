using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;

namespace MvcProject.Controllers
{
    public class WriterPanelContentController : Controller
    {
        private ContentManager cm = new ContentManager(new EfContentDal());
        // GET: WriterPanelContent
        public ActionResult MyContent(string p)
        {
            Context c = new Context();
            int id=2;
            p = (string) Session["WriterMail"];
            var writeridınfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
            //ViewBag.d = p;
            var contentvalues = cm.GetListByWriterID(id);
            return View(contentvalues);
        }
      
    }
}