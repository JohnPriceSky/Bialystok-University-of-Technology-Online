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

        [HttpGet, Route("api/attributes/")]
        public IEnumerable<AttributeViewModel> GetCategoryAttributes() => _categoryService.GetAttributes();

        [HttpGet, Route("api/category/attributes/{categoryId}")]
        public IEnumerable<AttributeViewModel> GetCategoryAttributes([FromUri]long categoryId)
        {
            var result = new List<AttributeViewModel>();
            _categoryService.GetCategoryAttributes(categoryId, ref result);

            return result;
        }
    }
}
