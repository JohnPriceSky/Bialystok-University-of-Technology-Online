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
                    Id = n.Id,
                    Title = n.Title,
                    ImageUrl = n.ImageUrl,
                    Description = n.Description,
                    Created = n.Created,
                    Owner = n.UserName
                })
                .OrderByDescending(n => n.Created)
                .ToList();
        }

        public NoticeViewModel GetNotice(long noticeId)
        {
            return _buotDb.Notice.AsNoTracking()
                .Select(n => new NoticeViewModel
                {
                    Id = n.Id,
                    Title = n.Title,
                    ImageUrl = n.ImageUrl,
                    Description = n.Description,
                    Content = n.Content,
                    Created = n.Created,
                    Owner = n.UserName
                })
                .FirstOrDefault(n => n.Id == noticeId);
        }

        public IEnumerable<CategoryViewModel> GetNoticeCategories(long noticeId)
        {
            return _buotDb.Notice.AsNoTracking()
                .Where(n => n.Id == noticeId)
                .SelectMany(n => n.Category)
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    ParentId = c.ParentId
                })
                .ToList();
        }

        public IEnumerable<NoticeViewModel> GetNoticesByCategory(long categoryId)
        {
            return _buotDb.Category.AsNoTracking()
                .Where(c => c.Id == categoryId)
                .SelectMany(c => c.Notice)
                .Select(n => new NoticeViewModel
                {
                    Id = n.Id,
                    Title = n.Title,
                    ImageUrl = n.ImageUrl,
                    Description = n.Description,
                    Content = n.Content,
                    Created = n.Created,
                    Owner = n.UserName,
                    CurrentCategoryId = categoryId
                })
                .ToList();
        }

        public void AddNotice(NoticeViewModel notice, string userName)
        {
            var categoriesIds = GetCategoriesIds(notice.CategoriesIds);

            var categories = _buotDb.Category
                .Join(inner: categoriesIds,
                    outerKeySelector: c => c.Id,
                    innerKeySelector: id => id,
                    resultSelector: (c, id) => c)
                .OrderByDescending(c => c.Id)
                .ToList();

            var categoriesToRemove = new List<Category>();
            categories.ForEach(cat =>
            {
                if (cat.ParentId > 0)
                {
                    var parent = categories.FirstOrDefault(c => c.Id == cat.ParentId);
                    if (categories.Contains(parent))
                        categoriesToRemove.Add(parent);
                }
            });

            categoriesToRemove.ForEach(c =>
            {
                categories.Remove(c);
            });

            _buotDb.Notice.Add(new Notice
            {
                Title = notice.Title,
                ImageUrl = notice.ImageUrl,
                Description = notice.Description,
                Created = DateTime.Now,
                Category = categories,
                Content = notice.Content,
                UserName = userName
            });
            _buotDb.SaveChanges();
        }

        public void EditNotice(NoticeViewModel notice)
        {
            var dbNotice = _buotDb.Notice.FirstOrDefault(n => n.Id == notice.Id);
            if (!dbNotice.Title.Equals(notice.Title))
                dbNotice.Title = notice.Title;

            if (!dbNotice.ImageUrl.Equals(notice.ImageUrl))
                dbNotice.ImageUrl = notice.ImageUrl;

            if (!dbNotice.Description.Equals(notice.Description))
                dbNotice.Description = notice.Description;

            if (!dbNotice.Content.Equals(notice.Content))
                dbNotice.Content = notice.Content;

            _buotDb.SaveChanges();
        }

        public void DeleteNotice(long noticeId)
        {
            var notice = _buotDb.Notice.FirstOrDefault(n => n.Id == noticeId);

            var categories = notice.Category.ToList();
            for (var i = 0; i < categories.Count; i++)
            {
                notice.Category.Remove(categories[i]);
            }

            _buotDb.Notice.Remove(notice);
            _buotDb.SaveChanges();
        }

        private List<long> GetCategoriesIds(string categoriesIds)
            => categoriesIds.Split(',').Select(id => long.Parse(id)).ToList();
    }
}
