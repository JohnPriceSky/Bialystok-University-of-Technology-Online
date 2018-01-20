using BUOTOnline.DAL.IServices;
using BUOTOnline.DAL.ViewModels;
using BUOTOnline.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BUOTOnline.Web.Controllers
{
    public class NoticeController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly INoticeService _noticeService;

        public NoticeController(ApplicationDbContext applicationDbContext, INoticeService noticeService)
        {
            _applicationDbContext = applicationDbContext;
            _noticeService = noticeService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Notice(long id)
        {
            var notice = _noticeService.GetNotice(id);

            return View(notice);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(NoticeViewModel notice)
        {
            _noticeService.AddNotice(notice, User.Identity.Name);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Edit(long id)
        {
            var notice = _noticeService.GetNotice(id);

            return View(notice);
        }

        [HttpPost]
        public ActionResult Edit(NoticeViewModel notice)
        {
            _noticeService.EditNotice(notice);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Delete(long id)
        {
            _noticeService.DeleteNotice(id);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult AddButton()
        {
            return PartialView("~/Views/Notice/_AddButton.cshtml");
        }

        public ActionResult EditButton(string owner, string noticeId)
        {
            if (owner != null && owner.Equals(User.Identity.Name))
                return PartialView("~/Views/Notice/_EditButton.cshtml", noticeId);
            else
                return Content(string.Empty);
        }

        public ActionResult NoticeCategories(long noticeId)
        {
            var categories = _noticeService.GetNoticeCategories(noticeId);
            return PartialView("~/Views/Notice/_NoticeCategories.cshtml", categories);
        }

        public ActionResult DeleteButton(string owner, string noticeId)
        {
            if (owner != null && owner.Equals(User.Identity.Name))
                return PartialView("~/Views/Notice/_DeleteButton.cshtml", noticeId);
            else
                return Content(string.Empty);
        }
    }
}