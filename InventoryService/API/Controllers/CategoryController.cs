using InventoryService.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.API.Controllers.CategoryController
{

    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController(ICategoryService service) : ControllerBase
    {
        private readonly ICategoryService _categoryService = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
        {

            IEnumerable<Category> categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Category Id.");

            Category category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
                return NotFound($"The Category with Id {id} is Not Found.");
            return category;
        }

        [HttpPost]
        public async Task<ActionResult<Category>> AddCategory(Category category)
        {
            if (category == null)
                return BadRequest("This is a Bad Request.");
            return await _categoryService.CreateCategoryAsync(category);
        }

        [HttpPut]
        public async Task<ActionResult<Category>> UpdateCategory(int id, Category category)
        {
            return await _categoryService.UpdateCategoryAsync(id, category);
        }

        [HttpDelete]
        public async Task<ActionResult<int>> DeleteCategory(int id)
        {
            return await _categoryService.DeleteCategoryAsync(id);
        }

        [HttpGet("[action]/{searchText:alpha}")]
        public async Task<ActionResult<IEnumerable<Category>>> SearchCategories(string searchText)
        {
            IEnumerable<Category> categories = await _categoryService.SearchCategoriesAsync(searchText);
            return categories.ToList();
        }
    }
}