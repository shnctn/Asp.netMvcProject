using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProject.Models;

namespace MvcProject.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult CategoryChart()
        {
            return Json(blogList(), JsonRequestBehavior.AllowGet);
        }

        public List<CategoryClass> blogList()
        {
            List<CategoryClass> ct = new List<CategoryClass>();
            ct.Add(new CategoryClass()
            {
                CategoryName = "Yazılım",
                CategoryCount = 8
            });
               
            ct.Add(new CategoryClass()
            {
                CategoryName = "Teknoloji",
                CategoryCount = 2
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "spor",
                CategoryCount = 1
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "seyahat",
                CategoryCount = 6
            });
            return ct;
        }
    }
}