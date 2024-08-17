namespace InventoryService.Domain.Interfaces
{
    public interface IProductService{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product> GetProductByIdAsync(int productId);
    Task<Product> CreateProductAsync(Product product);
    Task<Product> UpdateProductAsync(Product product);
    Task<bool> DeleteProductAsync(int productId);

    //I'm using List here because I want to modify the return result. In case of IEnumerable, I can't do this because it is read-only
    Task<List<Product>> GetProductByNameAsync(string productName);
    }
}
