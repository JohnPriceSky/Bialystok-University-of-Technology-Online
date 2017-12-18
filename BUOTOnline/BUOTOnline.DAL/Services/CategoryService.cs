using BUOTOnline.DAL.IServices;
using BUOTOnline.DAL.Models;
using BUOTOnline.DAL.ViewModels;
using System.Collections.Generic;
using System.Linq;

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
                    ParentId = c.ParentId ?? 0,
                    Attributes = c.Attribute.Select(a => new AttributeViewModel { Id = a.Id, Name = a.Name, Type = a.Type }),
                })
                .ToList();
        }
    }
}
