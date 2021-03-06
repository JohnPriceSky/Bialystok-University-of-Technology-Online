﻿using BUOTOnline.DAL.IServices;
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

        public IEnumerable<CategoryViewModel> GetLowestCategories()
        {
            return _buotDb.Category.AsNoTracking()
                .Where(c => !c.ParentId.HasValue)
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    ParentId = c.ParentId
                })
                .ToList();
        }

        public IEnumerable<CategoryViewModel> GetChildrenCategories(long categoryId)
        {
            return _buotDb.Category.AsNoTracking()
                .Where(c => c.ParentId == categoryId)
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

        public CategoryViewModel GetCategory(long categoryId)
        {
            var attributes = _buotDb.Category.AsNoTracking()
                .Where(c => c.Id == categoryId)
                .SelectMany(c => c.Attribute)
                .Select(a => a.Id)
                .ToArray();

            var attributesIds = String.Join(",", attributes);

            return _buotDb.Category.AsNoTracking()
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    ParentId = c.ParentId,
                    AttributeIds = attributesIds
                })
                .FirstOrDefault(c => c.Id == categoryId);
        }

        public void GetInheritedCategories(long categoryId, ref List<CategoryViewModel> categories)
        {
            var parentCategory = _buotDb.Category.AsNoTracking()
                .Where(c => c.Id == categoryId && c.ParentId.HasValue)
                .Select(c => c.Category2)
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    ParentId = c.ParentId
                })
                .FirstOrDefault();

            if (parentCategory != null)
            {
                categories.Add(parentCategory);
                GetInheritedCategories(parentCategory.Id, ref categories);
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

        public IEnumerable<string> GetStates()
        {
            return _buotDb.State.AsNoTracking().Select(s => s.Value).ToList();
        }

        public void AddState(string state)
        {
            _buotDb.State.Add(new State { Value = state });
            _buotDb.SaveChanges();
        }

        public void DeleteState(string state)
        {
            var dbState = _buotDb.State.FirstOrDefault(s => s.Value.Equals(state));

            _buotDb.State.Remove(dbState);
            _buotDb.SaveChanges();
        }

        public IEnumerable<string> GetSizes()
        {
            return _buotDb.Size.AsNoTracking().Select(s => s.Value).ToList();
        }

        public void AddSize(string size)
        {
            _buotDb.Size.Add(new Size { Value = size });
            _buotDb.SaveChanges();
        }

        public void DeleteSize(string size)
        {
            var dbSize = _buotDb.Size.FirstOrDefault(s => s.Value.Equals(size));

            _buotDb.Size.Remove(dbSize);
            _buotDb.SaveChanges();
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

            if (attributes.Count > 0)
                newCategory.Attribute = attributes;

                _buotDb.Category.Add(newCategory);
            _buotDb.SaveChanges();
        }

        public void EditCategory(CategoryViewModel category)
        {
            var attributesIds = GetAttributesIds(category.AttributeIds);

            var attributes = _buotDb.Attribute
                .Join(inner: attributesIds,
                    outerKeySelector: a => a.Id,
                    innerKeySelector: id => id,
                    resultSelector: (a, id) => a)
                    .ToList();

            var dbCategory = _buotDb.Category.FirstOrDefault(c => c.Id == category.Id);
            if (!dbCategory.Name.Equals(category.Name, StringComparison.InvariantCultureIgnoreCase))
                dbCategory.Name = category.Name;

            if (dbCategory.ParentId != category.ParentId)
                dbCategory.ParentId = category.ParentId;

            var dbAttributes = dbCategory.Attribute.ToList();

            foreach (var attribute in dbAttributes)
            {
                if (!attributes.Contains(attribute))
                    dbCategory.Attribute.Remove(attribute);
            }

            foreach (var attribute in attributes)
            {
                if (!dbAttributes.Contains(attribute))
                    dbCategory.Attribute.Add(attribute);
            }

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
