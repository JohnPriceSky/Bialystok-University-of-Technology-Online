using BUOTOnline.DAL.IServices;
using BUOTOnline.DAL.ViewModels;
using System;
using System.Collections.Generic;

namespace BUOTOnline.DAL.Services
{
    class CategoryService : ICategoryService
    {
        public IEnumerable<CategoryViewModel> GetCategories()
        {
            return new List<CategoryViewModel>
            {
                new CategoryViewModel
                {
                    Id = 1, Name = "Vehicles", ParentId = 0, Attributes = new List<AttributeViewModel>
                    {
                        new AttributeViewModel { Id = 1, Name = "Title", Type = AttributeType.Shorttext },
                        new AttributeViewModel { Id = 2, Name = "Descrition", Type = AttributeType.Longtext }
                    }
                },
                new CategoryViewModel
                {
                    Id = 2, Name = "Tank", ParentId = 1, Attributes = new List<AttributeViewModel>
                    {
                        new AttributeViewModel { Id = 1, Name = "Title", Type = AttributeType.Shorttext },
                        new AttributeViewModel { Id = 2, Name = "Descrition", Type = AttributeType.Longtext }
                    }
                },
                new CategoryViewModel
                {
                    Id = 3, Name = "Car", ParentId = 1, Attributes = new List<AttributeViewModel>
                    {
                        new AttributeViewModel { Id = 1, Name = "Title", Type = AttributeType.Shorttext },
                        new AttributeViewModel { Id = 2, Name = "Descrition", Type = AttributeType.Longtext }
                    }
                },
                new CategoryViewModel
                {
                    Id = 4, Name = "Sedan", ParentId = 2, Attributes = new List<AttributeViewModel>
                    {
                        new AttributeViewModel { Id = 1, Name = "Title", Type = AttributeType.Shorttext },
                        new AttributeViewModel { Id = 2, Name = "Descrition", Type = AttributeType.Longtext }
                    }
                },
                new CategoryViewModel
                {
                    Id = 5, Name = "Combi", ParentId = 2, Attributes = new List<AttributeViewModel>
                    {
                        new AttributeViewModel { Id = 1, Name = "Title", Type = AttributeType.Shorttext },
                        new AttributeViewModel { Id = 2, Name = "Descrition", Type = AttributeType.Longtext }
                    }
                },
                new CategoryViewModel
                {
                    Id = 6, Name = "Food", ParentId = 0, Attributes = new List<AttributeViewModel>
                    {
                        new AttributeViewModel { Id = 1, Name = "Title", Type = AttributeType.Shorttext },
                        new AttributeViewModel { Id = 2, Name = "Descrition", Type = AttributeType.Longtext }
                    }
                }
            };
        }
    }
}
