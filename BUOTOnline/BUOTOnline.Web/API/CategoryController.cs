using BUOTOnline.DAL.IServices;
using BUOTOnline.DAL.ViewModels;
using System.Collections.Generic;
using System.Web.Http;

namespace BUOTOnline.Web.API
{
    public class CategoryController : ApiController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet, Route("api/categories/")]
        public IEnumerable<CategoryViewModel> GetCategories() => _categoryService.GetCategories();

        [HttpGet, Route("api/attributes/")]
        public IEnumerable<AttributeViewModel> GetCategoryAttributes() => _categoryService.GetAttributes();

        [HttpGet, Route("api/category/parents/{categoryId}")]
        public IEnumerable<CategoryViewModel> GetInheritedCategories([FromUri]long categoryId)
        {
            var result = new List<CategoryViewModel>();
            _categoryService.GetInheritedCategories(categoryId, ref result);

            return result;
        }

        [HttpGet, Route("api/category/attributes/{categoryId}")]
        public IEnumerable<AttributeViewModel> GetCategoryAttributes([FromUri]long categoryId)
        {
            var result = new List<AttributeViewModel>();
            _categoryService.GetCategoryAttributes(categoryId, ref result);

            return result;
        }
    }
}
