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
                .OrderByDescending(n => n.Created)
                .ToList();
        }

        public void AddNotice(NoticeViewModel notice)
        {
            var categoriesIds = GetCategoriesIds(notice.CategoriesIds);

            var categories = _buotDb.Category
                .Join(inner: categoriesIds,
                    outerKeySelector: c => c.Id,
                    innerKeySelector: id => id,
                    resultSelector: (c, id) => c)
                .OrderBy(c => c.Id)
                .ToList();

            var categoriesIdsToRemove = new List<int>();
            categories.ForEach(cat =>
            {
                if (cat.ParentId > 0)
                {
                    var parent = categories.FirstOrDefault(c => c.ParentId == _buotDb.Category.Select(p => p.Id).FirstOrDefault(id => id == c.ParentId));
                    if (categories.Contains(parent))
                        categoriesIdsToRemove.Add(categories.IndexOf(parent));
                }
            });
            categoriesIdsToRemove.ForEach(ind =>
            {
                categories.RemoveAt(ind);
            });

            _buotDb.Notice.Add(new Notice
            {
                Title = notice.Title,
                ImageUrl = notice.ImageUrl,
                Description = notice.Description,
                Created = DateTime.Now,
                Category = categories,
                Content = notice.Content
            });
            _buotDb.SaveChanges();
        }

        private List<long> GetCategoriesIds(string categoriesIds)
            => categoriesIds.Split(',').Select(id => long.Parse(id)).ToList();
    }
}
