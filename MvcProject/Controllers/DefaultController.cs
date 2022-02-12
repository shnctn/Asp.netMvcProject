using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccess.EntityFramework;

namespace MvcProject.Controllers
{    [AllowAnonymous]
    public class DefaultController : Controller
    {
    
        private HeadingManager hm = new HeadingManager(new EfHeadingDal());

        private ContentManager cm = new ContentManager(new EfContentDal());
        // GET: Default
        public ActionResult Heading()
        {
            var headinglist = hm.GetList();
            return View(headinglist);
        }

        public PartialViewResult Index(int id=1)
        {
            var contentlist = cm.GetListByHeadingID(id);
            return PartialView(contentlist);
        }
    }
}