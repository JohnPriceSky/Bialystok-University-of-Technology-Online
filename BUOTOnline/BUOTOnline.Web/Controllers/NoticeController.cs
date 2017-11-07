using BUOTOnline.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BUOTOnline.Web.Controllers
{
    public class NoticeController : Controller
    {
        // GET: Notice
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(NoticeViewModel notice)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Msg = $"Title: {notice.Title}, Description: {notice.Description}, Created: {notice.Created}";
            }
            else
            {
                ViewBag.Msg = "Błędne dane.";
            }

            return View();
        }

        public ActionResult AddButton()
        {
            return PartialView("~/Views/Notice/_AddButton.cshtml");
        }
    }
}