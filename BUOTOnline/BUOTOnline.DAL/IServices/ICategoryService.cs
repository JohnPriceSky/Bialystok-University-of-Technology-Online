using BUOTOnline.DAL.ViewModels;
using System.Collections.Generic;

namespace BUOTOnline.DAL.IServices
{
    public interface ICategoryService
    {
        IEnumerable<CategoryViewModel> GetCategories();
        IEnumerable<CategoryViewModel> GetLowestCategories();
        IEnumerable<CategoryViewModel> GetChildrenCategories(long categoryId);
        CategoryViewModel GetCategory(long categoryId);
        IEnumerable<AttributeViewModel> GetAttributes();
        void GetInheritedCategories(long categoryId, ref List<CategoryViewModel> categories);
        void GetCategoryAttributes(long categoryId, ref List<AttributeViewModel> attributes);
        void AddCategory(CategoryViewModel category);
        void EditCategory(CategoryViewModel category);
        void DeleteCategory(long categoryId);
        IEnumerable<string> GetStates();
        IEnumerable<string> GetSizes();
        void AddState(string state);
        void AddSize(string size);
        void DeleteState(string state);
        void DeleteSize(string size);
    }
}
