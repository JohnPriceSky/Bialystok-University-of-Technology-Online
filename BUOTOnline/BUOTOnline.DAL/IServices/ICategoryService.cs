using BUOTOnline.DAL.ViewModels;
using System.Collections.Generic;

namespace BUOTOnline.DAL.IServices
{
    public interface ICategoryService
    {
        IEnumerable<CategoryViewModel> GetCategories();
        void GetInheritedCategories(long categoryId, ref List<CategoryViewModel> categories);
        IEnumerable<AttributeViewModel> GetInheritedAttributes(long categoryId);
        IEnumerable<AttributeViewModel> GetCategoryAttributes(long categoryId);
        void AddCategory(CategoryViewModel category);
        void DeleteCategory(long categoryId);
    }
}
