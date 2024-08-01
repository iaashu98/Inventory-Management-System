namespace InventoryService.Domain.Interfaces
{
    public interface IProductService{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product> GetProductByIdAsync(int productId);
    Task<Product> CreateProductAsync(Product product);
    Task<Product> UpdateProductAsync(int productId, Product product);
    Task<bool> DeleteProductAsync(int productId);
    }
}
