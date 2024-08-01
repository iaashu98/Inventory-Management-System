namespace InventoryService.Domain.Interfaces
{
    public interface ICategoryService{
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
    Task<Category> GetCategoryByIdAsync(int categoryId);
    Task<Category> CreateCategoryAsync(Category category);
    Task<Category> UpdateCategoryAsync(int categoryId, Category category);
    Task<bool> DeleteCategoryAsync(int categoryId);
    }
}