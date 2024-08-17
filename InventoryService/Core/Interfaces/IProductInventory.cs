namespace InventoryService.Core.Interfaces
{
    public interface IProductInventoryService{
        Task<IEnumerable<ProductInventory>> GetAllProductInventoryAsync();
        Task<ProductInventory> GetProductInventoryByIdAsync(int productInventoryId);
        Task<ProductInventory> CreateProductInventoryAsync(ProductInventory productInventory);
        Task<ProductInventory> UpdateProductInventoryAsync(int productInventoryId, ProductInventory productInventory);
        Task<int> DeleteProductInventoryAsync(int productInventoryId);
    }
}