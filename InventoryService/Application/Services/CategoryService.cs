
using InventoryService.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

public class CategoryService : ICategoryService
{
    private readonly ApplicationDbContext _context;
    public CategoryService(ApplicationDbContext dbContext)
    {
        _context = dbContext;   
    }
    
    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public Task<Category> CreateCategoryAsync(Category category)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteCategoryAsync(int categoryId)
    {
        throw new NotImplementedException();
    }

    public Task<Category> UpdateCategoryAsync(int categoryId, Category category)
    {
        throw new NotImplementedException();
    }

    public Task<Category> GetCategoryByIdAsync(int categoryId)
    {
        throw new NotImplementedException();
    }
}
