using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BusinessLayer.Concrete;
using DataAccess.EntityFramework;
using EntityLayer.Concrete;


namespace MvcProject.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private HeadingManager hm = new HeadingManager(new EfHeadingDal());
        private WriterLoginManager wlm = new WriterLoginManager(new EfWriterDal());


        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult HomePage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HomePage(Writer w)
        {

            var adminuser = wlm.GetWriter(w.WriterMail, w.WriterPassword);
            if (adminuser != null)
            {
                FormsAuthentication.SetAuthCookie(adminuser.WriterMail, false);
                Session["UserName"] = adminuser.WriterName;
                return RedirectToAction("Index", "Writer");
            }
            else
            {
                return RedirectToAction("Heading","Default");
            }

        }

    }
}