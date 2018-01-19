using BUOTOnline.DAL.IServices;
using System.Web.Mvc;

namespace BUOTOnline.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly INoticeService _noticeService;

        public HomeController(INoticeService noticeService)
        {
            _noticeService = noticeService;
        }

        public ActionResult Index() => View(_noticeService.GetNotices());
    }
}