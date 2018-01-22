using BUOTOnline.DAL;
using BUOTOnline.DAL.IServices;
using BUOTOnline.DAL.ViewModels;
using BUOTOnline.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BUOTOnline.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ApplicationDbContext _applicationDbContext;

        public AdminController(ICategoryService categoryService, ApplicationDbContext applicationDbContext)
        {
            _categoryService = categoryService;
            _applicationDbContext = applicationDbContext;
        }

        public ActionResult Index() => View();

        public ActionResult Dictionaries() => View();

        public ActionResult Categories() => View(_categoryService.GetCategories());

        public ActionResult Category(long id)
        {
            return View();
        }

        public ActionResult AddCategory()
        {
            var category = new CategoryViewModel
            {
                Parents = _categoryService.GetCategories()
            };

            return View(category);
        }

        [HttpPost]
        public ActionResult AddCategory(CategoryViewModel category)
        {
            _categoryService.AddCategory(category);

            return RedirectToAction("Categories");
        }

        public ActionResult EditCategory(long id)
        {
            var category = _categoryService.GetCategory(id);
            category.Parents = _categoryService.GetCategories();

            return View(category);
        }

        [HttpPost]
        public ActionResult EditCategory(CategoryViewModel category)
        {
            _categoryService.EditCategory(category);

            return RedirectToAction("Categories");
        }

        public ActionResult DeleteCategory(long id)
        {
            _categoryService.DeleteCategory(id);

            return RedirectToAction("Categories");
        }

        public ActionResult UsersManagement()
        {
            var users = _applicationDbContext.Users
                .Select(u => new UserViewModel
                {
                    Id = u.Id,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber,
                    UserName = u.UserName,
                    Role = _applicationDbContext.Roles.Where(r => u.Roles.Select(ur => ur.RoleId).Contains(r.Id)).Select(r => r.Name).FirstOrDefault()
                }).ToList();

            return View(users);
        }

        public ActionResult EditUser(string id)
        {
            var user = _applicationDbContext.Users
                .Select(u => new UserViewModel
                {
                    Id = u.Id,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber,
                    UserName = u.UserName,
                    Role = _applicationDbContext.Roles.Where(r => u.Roles.Select(ur => ur.RoleId).Contains(r.Id)).Select(r => r.Name).FirstOrDefault()
                }).FirstOrDefault(u => u.Id == id);

            user.Roles = _applicationDbContext.Roles.Select(r => r.Name).ToList();

            return View(user);
        }

        [HttpPost]
        public ActionResult UpdateUser(UserViewModel user)
        {
            var dbUser = _applicationDbContext.Users.FirstOrDefault(u => u.Id == user.Id);

            var hasChenged = false;

            if (user.UserName != null && (dbUser.UserName == null || !dbUser.UserName.Equals(user.UserName)))
            {
                hasChenged = true;

                dbUser.UserName = user.UserName;
            }

            if (user.PhoneNumber != null && (dbUser.PhoneNumber == null || !dbUser.PhoneNumber.Equals(user.PhoneNumber)))
            {
                hasChenged = true;

                dbUser.PhoneNumber = user.PhoneNumber;
            }

            if (!string.IsNullOrEmpty(user.Role))
            {
                var role = _applicationDbContext.Roles.Where(r => r.Name == user.Role).FirstOrDefault();
                var dbRole = _applicationDbContext.Users.Where(u => u.Id == user.Id)
                    .Select(u => _applicationDbContext.Roles.Where(r => u.Roles.Select(ur => ur.RoleId).Contains(r.Id))
                    .FirstOrDefault()).FirstOrDefault();
                if (dbRole == null || !dbRole.Name.Equals(user.Role))
                {
                    hasChenged = true;

                    if (dbRole != null)
                    {
                        dbUser.Roles.Remove(dbUser.Roles.FirstOrDefault());
                    }

                    dbUser.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole
                    {
                        RoleId = role.Id,
                        UserId = user.Id
                    });
                }
            }

            if (hasChenged)
                _applicationDbContext.SaveChanges();

            return RedirectToAction("UsersManagement");
        }

        public ActionResult SizeDict()
        {
            return PartialView("~/Views/Admin/_SizeDict.cshtml", _categoryService.GetSizes());
        }

        public ActionResult StateDict()
        {
            return PartialView("~/Views/Admin/_StateDict.cshtml", _categoryService.GetStates());
        }

        [HttpPost]
        public ActionResult AddSize(string size)
        {
            _categoryService.AddSize(size);

            return RedirectToAction("Dictionaries");
        }

        [HttpPost]
        public ActionResult AddState(string state)
        {
            _categoryService.AddState(state);

            return RedirectToAction("Dictionaries");
        }

        public ActionResult RemoveSize(string size)
        {
            _categoryService.DeleteSize(size);

            return RedirectToAction("Dictionaries");
        }

        public ActionResult RemoveState(string state)
        {
            _categoryService.DeleteState(state);

            return RedirectToAction("Dictionaries");
        }
    }
}