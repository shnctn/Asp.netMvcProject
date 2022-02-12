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
    
    public class ContentController : Controller
    {
        // GET: Content
        private ContentManager cm = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            return View();
        }

      
        public ActionResult GetAllContent(string p)
        {
            if (p==null)
            {
                var values = cm.GetList();
                return View(values);
            }
            else
            {
                var values = cm.GetList(p);
                return View(values);
            }
        }
        public ActionResult ContentByHeading(int id)
        {
            var contentvalues = cm.GetListByHeadingID(id);
            return View(contentvalues);
        }
    }
}