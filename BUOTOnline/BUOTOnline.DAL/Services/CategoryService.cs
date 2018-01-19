using BUOTOnline.DAL.IServices;
using BUOTOnline.DAL.Models;
using BUOTOnline.DAL.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System;

namespace BUOTOnline.DAL.Services
{
    class CategoryService : ICategoryService
    {
        private readonly BUOTOdb _buotDb;

        public CategoryService(BUOTOdb buotDb)
        {
            _buotDb = buotDb;
        }

        public IEnumerable<CategoryViewModel> GetCategories()
        {
            return _buotDb.Category.AsNoTracking()
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    ParentId = c.ParentId
                })
                .ToList();
        }

        public void GetInheritedCategories(long categoryId, ref List<CategoryViewModel> categories)
        {
            var parenCategory = _buotDb.Category.AsNoTracking()
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    ParentId = c.ParentId
                })
                .FirstOrDefault(c => c.Id == categoryId && c.ParentId.HasValue);

            if (parenCategory != null)
            {
                categories.Add(parenCategory);
                GetInheritedCategories(parenCategory.Id, ref categories);
            }
        }

        public IEnumerable<AttributeViewModel> GetInheritedAttributes(long categoryId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<AttributeViewModel> GetCategoryAttributes(long categoryId)
        {
            throw new System.NotImplementedException();
        }

        public void AddCategory(CategoryViewModel category)
        {
            var attributesIds = GetAttributesIds(category.AttributeIds);

            var attributes = _buotDb.Attribute.AsNoTracking()
                .Join(inner: attributesIds,
                    outerKeySelector: a => a.Id,
                    innerKeySelector: id => id,
                    resultSelector: (a, id) => a)
                .ToList();

            _buotDb.Category.Add(new Category
            {
                Name = category.Name,
                ParentId = category.ParentId,
                Attribute = attributes
            });
            _buotDb.SaveChanges();
        }

        public void DeleteCategory(long categoryId)
        {
            if (_buotDb.Category.FirstOrDefault(c => c.Id == categoryId).Notice.Count > 0)
                return;

            var categories = GetCategories().ToList();
            categories.ForEach((category) =>
            {
                if (category.ParentId == categoryId)
                    DeleteCategory(category.Id);
            });

            _buotDb.Category.Remove(_buotDb.Category.FirstOrDefault(c => c.Id == categoryId));
            _buotDb.SaveChanges();
        }

        private IEnumerable<long> GetAttributesIds(string attributeIds)
            => attributeIds.Split(',').Select(id => long.Parse(id));
    }
}
