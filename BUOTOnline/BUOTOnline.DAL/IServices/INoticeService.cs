using BUOTOnline.DAL.ViewModels;
using System.Collections.Generic;

namespace BUOTOnline.DAL.IServices
{
    public interface INoticeService
    {
        IEnumerable<NoticeViewModel> GetNotices();
        NoticeViewModel GetNotice(long noticeId);
        IEnumerable<CategoryViewModel> GetNoticeCategories(long noticeId);
        IEnumerable<NoticeViewModel> GetNoticesByCategory(long categoryId);
        void AddNotice(NoticeViewModel notice, string userId);
        void EditNotice(NoticeViewModel notice);
        void DeleteNotice(long noticeId);
    }
}
