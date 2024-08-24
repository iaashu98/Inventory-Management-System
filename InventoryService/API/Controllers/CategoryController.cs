using AutoMapper;
using InventoryService.Core.DTOs;
using InventoryService.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.API.Controllers.CategoryController
{

    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController(ICategoryService service, IMapper mapper) : ControllerBase
    {
        private readonly ICategoryService _categoryService = service;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAllCategories()
        {
            IEnumerable<Category> categories = await _categoryService.GetAllCategoriesAsync();
            IEnumerable<CategoryDTO> categoryDTOs = _mapper.Map<IEnumerable<CategoryDTO>>(categories);
            return categoryDTOs.ToList();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> GetCategoryById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Category Id.");

            Category category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
                return NotFound($"The Category with Id {id} is Not Found.");
            return _mapper.Map<CategoryDTO>(category);;
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> AddCategory(CategoryDTO categoryDTO)
        {
            if (categoryDTO == null)
                return BadRequest("This is a Bad Request.");

            Category category = _mapper.Map<Category>(categoryDTO);
            Category createdCategory = await _categoryService.CreateCategoryAsync(category);
            return _mapper.Map<CategoryDTO>(createdCategory);
        }

        [HttpPut]
        public async Task<ActionResult<CategoryDTO>> UpdateCategory(int id, CategoryDTO categoryDTO)
        {
            Category category = _mapper.Map<Category>(categoryDTO);
            Category updatedCategory = await _categoryService.UpdateCategoryAsync(id, category);
            return _mapper.Map<CategoryDTO>(updatedCategory);
        }

        [HttpDelete]
        public async Task<ActionResult<int>> DeleteCategory(int id)
        {
            return await _categoryService.DeleteCategoryAsync(id);
        }

        [HttpGet("[action]/{searchText:alpha}")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> SearchCategories(string searchText)
        {
            IEnumerable<Category> categories = await _categoryService.SearchCategoriesAsync(searchText);
            IEnumerable<CategoryDTO> categoryDTOs = _mapper.Map<IEnumerable<CategoryDTO>>(categories);
            return categoryDTOs.ToList();
        }
    }
}