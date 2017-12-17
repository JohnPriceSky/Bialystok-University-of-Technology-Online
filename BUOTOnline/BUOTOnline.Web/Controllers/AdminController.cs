using BUOTOnline.DAL;
using BUOTOnline.DAL.IServices;
using BUOTOnline.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BUOTOnline.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly ICategoryService _categoryService;

        public AdminController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Categories() => View(_categoryService.GetCategories());

        public ActionResult Category(long id)
        {
            return View();
        }

        public ActionResult AddCategory()
        {
            var category = new CategoryViewModel
            {
                Parents = new List<CategoryViewModel>
                {
                    new CategoryViewModel { Id = 1, Name = "Vehicles", ParentId = 0 },
                    new CategoryViewModel { Id = 2, Name = "Tank", ParentId = 1 },
                    new CategoryViewModel {  Id = 3, Name = "Car", ParentId = 1 },
                    new CategoryViewModel { Id = 4, Name = "Sedan", ParentId = 2 },
                    new CategoryViewModel { Id = 5, Name = "Combi", ParentId = 2 },
                    new CategoryViewModel { Id = 6, Name = "Food", ParentId = 0 }
                },
                Attributes = new List<AttributeViewModel>
                {
                    new AttributeViewModel { Id = 1, Name = "Title", Type = AttributeType.Shorttext },
                    new AttributeViewModel { Id = 2, Name = "Descrition", Type = AttributeType.Longtext },
                    new AttributeViewModel { Id = 3, Name = "SecondHand", Type = AttributeType.Bool },
                    new AttributeViewModel { Id = 4, Name = "Age", Type = AttributeType.Int }
                }
            };

            return View(category);
        }
    }
}