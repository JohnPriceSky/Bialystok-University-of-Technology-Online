using BUOTOnline.DAL.ViewModels;
using System.Collections.Generic;

namespace BUOTOnline.DAL.IServices
{
    public interface INoticeService
    {
        IEnumerable<NoticeViewModel> GetNotices();
    }
}
