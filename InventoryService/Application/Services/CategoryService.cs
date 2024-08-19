using InventoryService.Application.Validators;
using InventoryService.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        private readonly CategoryValidator _validator;
        public CategoryService(ApplicationDbContext dbContext, CategoryValidator categoryValidator)
        {
            _context = dbContext;
            _validator = categoryValidator;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            var validationResult = _validator.ValidateCategory(category);
            if (!validationResult.IsValid)
            {
                var errorMessage = string.Join(", ", validationResult.Errors);
                throw new ArgumentException($"Invalid category data: {errorMessage}");
            }

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<int> DeleteCategoryAsync(int categoryId)
        {
            Category category = await GetCategoryByIdAsync(categoryId);

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return categoryId;
        }

        public async Task<Category> UpdateCategoryAsync(int categoryId, Category category)
        {
            var validationResult = _validator.ValidateCategory(category);
            if (!validationResult.IsValid)
            {
                var errorMessage = string.Join(", ", validationResult.Errors);
                throw new ArgumentException($"Invalid category data: {errorMessage}");
            }

            Category existingCategory = await GetCategoryByIdAsync(categoryId);
            _context.Entry(existingCategory).CurrentValues.SetValues(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> GetCategoryByIdAsync(int categoryId)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.CategoryID == categoryId);
        }

        public async Task<IEnumerable<Category>> SearchCategoriesAsync(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
                return [];

            return await _context.Categories.Where(x => x.CategoryName.Contains(searchText) ||
                         x.Description.Contains(searchText)).ToListAsync();
        }
    }
}