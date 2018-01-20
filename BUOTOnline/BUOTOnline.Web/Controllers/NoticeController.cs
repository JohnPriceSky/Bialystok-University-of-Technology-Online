using BUOTOnline.DAL.IServices;
using BUOTOnline.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BUOTOnline.Web.Controllers
{
    public class NoticeController : Controller
    {
        private readonly INoticeService _noticeService;

        public NoticeController(INoticeService noticeService)
        {
            _noticeService = noticeService;
        }

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
            _noticeService.AddNotice(notice);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult AddButton()
        {
            return PartialView("~/Views/Notice/_AddButton.cshtml");
        }
    }
}