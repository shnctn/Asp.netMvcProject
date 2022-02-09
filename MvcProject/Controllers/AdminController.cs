using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccess.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;

namespace MvcProject.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        private CategoryManager cm = new CategoryManager(new EfCategoryDal());

        [Authorize(Roles = "B")]
        public ActionResult Index()
        {
            var categoryValues = cm.GetList();
            return View(categoryValues);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category c)
        {
            CategoryValidatior cv = new CategoryValidatior();
            ValidationResult result = cv.Validate(c);

            if (result.IsValid)
            {
                cm.CategoryAdd(c);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }
        
        public ActionResult DeleteCategory(int id)
        {
            var categoryvalue = cm.GetById(id);
            cm.CategoryDelete(categoryvalue);
            return RedirectToAction("Index");
        }

        public ActionResult EditCategory()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryvalue = cm.GetById(id);
            return View(categoryvalue);

        }
        [HttpPost]
        public ActionResult EditCategory(Category c)
        {
          cm.CategoryUpdate(c);
          return RedirectToAction("Index");

        }
    }
}