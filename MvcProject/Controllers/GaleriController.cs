using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccess.EntityFramework;

namespace MvcProject.Controllers
{
   
    public class GaleriController : Controller
    {
        private ImageFileManager im = new ImageFileManager(new EfImageDal());
        // GET: Galeri

        public ActionResult Index()
        {
            var values = im.GetList();
            return View(values);
        }
    }
}