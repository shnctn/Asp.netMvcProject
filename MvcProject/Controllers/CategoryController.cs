using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BusinessLayer.ValidationRules;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using FluentValidation;
using DataAccess.EntityFramework;
using EntityLayer.Concrete;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace MvcProject.Content
{
    
    public class CategoryController : Controller
    {
        // GET: Category
        private CategoryManager cm = new CategoryManager(new EfCategoryDal());
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategoryList()
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
                return RedirectToAction("GetCategoryList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                        ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
            }

            return View();
        }
    }
}