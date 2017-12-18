using BUOTOnline.DAL.IServices;
using BUOTOnline.DAL.Models;
using BUOTOnline.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BUOTOnline.DAL.Services
{
    class NoticeService : INoticeService
    {
        private readonly BUOTOdb _buotDb;

        public NoticeService(BUOTOdb buotDb)
        {
            _buotDb = buotDb;
        }

        public IEnumerable<NoticeViewModel> GetNotices()
        {
            return _buotDb.Notice.AsNoTracking()
                .Select(n => new NoticeViewModel
                {
                    Title = n.Title,
                    ImageUrl = n.ImageUrl,
                    Description = n.Description,
                    Created = n.Created
                })
                .ToList();
        }
    }
}
