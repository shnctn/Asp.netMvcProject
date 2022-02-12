using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using EntityLayer.Concrete;
using System.Web.Security;

namespace MvcProject.Controllers
{   [AllowAnonymous]
    public class LoginController : Controller
    {
        //private AdminManager adm = new AdminManager(new EfAdminDal());
        private WriterLoginManager wlm = new WriterLoginManager(new EfWriterDal());
        //private WriterManager wm = new WriterManager(new EfWriterDal());
        //// GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin a)
        {
            Context c = new Context();
            var adminuser = c.Admins.FirstOrDefault(x => x.UserName ==a.UserName && x.Password==a.Password);
            if (adminuser!=null)
            {
                FormsAuthentication.SetAuthCookie(adminuser.UserName,false);
                Session["UserName"] = adminuser.UserName;
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return RedirectToAction("Index");
            }
          
        }

        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer w)
        {
            //Context c = new Context();
            //var writeruser = c.Writers.FirstOrDefault(x => x.WriterMail == w.WriterMail && x.WriterPassword == w.WriterPassword);
            var writeruser = wlm.GetWriter(w.WriterMail, w.WriterPassword);
            if (writeruser != null)
            {
                FormsAuthentication.SetAuthCookie(writeruser.WriterMail, false);
                Session["WriterMail"] = writeruser.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Heading", "Default");

        }
    }
}