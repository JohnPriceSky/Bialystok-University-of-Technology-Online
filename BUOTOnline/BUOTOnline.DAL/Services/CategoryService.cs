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

        public IEnumerable<AttributeViewModel> GetAttributes()
        {
            return _buotDb.Attribute.AsNoTracking()
                .Select(a => new AttributeViewModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Type = a.Type
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

        public void GetCategoryAttributes(long categoryId, ref List<AttributeViewModel> attributes)
        {
            var category = _buotDb.Category.AsNoTracking()
                .FirstOrDefault(c => c.Id == categoryId);
            if (category.ParentId.HasValue)
            {
                GetCategoryAttributes(category.ParentId.Value, ref attributes);
            }

            foreach (var attribute in category.Attribute)
                attributes.Add(new AttributeViewModel
                {
                    Id = attribute.Id,
                    Name = attribute.Name,
                    Type = attribute.Type
                });
        }

        public void AddCategory(CategoryViewModel category)
        {
            var attributesIds = GetAttributesIds(category.AttributeIds);

            var attributes = _buotDb.Attribute
                .Join(inner: attributesIds,
                    outerKeySelector: a => a.Id,
                    innerKeySelector: id => id,
                    resultSelector: (a, id) => a)
                    .ToList();

            var newCategory = new Category
            {
                Name = category.Name,
            };

            if (category.ParentId > 0)
                newCategory.ParentId = category.ParentId;

            foreach (var attribute in attributes)
                newCategory.Attribute.Add(attribute);

            if (attributes.Count > 0)
                newCategory.Attribute = attributes;

                _buotDb.Category.Add(newCategory);
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

        private List<long> GetAttributesIds(string attributeIds)
            => attributeIds.Split(',').Select(id => long.Parse(id)).ToList();
    }
}
