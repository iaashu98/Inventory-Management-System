namespace InventoryService.Core.Interfaces
{
    public interface ICategoryService{
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
    Task<Category> GetCategoryByIdAsync(int categoryId);
    Task<Category> CreateCategoryAsync(Category category);
    Task<Category> UpdateCategoryAsync(int categoryId, Category category);
    Task<int> DeleteCategoryAsync(int categoryId);
    Task<IEnumerable<Category>> SearchCategoriesAsync(string searchText);
    }
}