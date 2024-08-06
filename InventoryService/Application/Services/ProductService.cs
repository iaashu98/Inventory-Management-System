using InventoryService.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

public class ProductService: IProductService{
    private readonly ApplicationDbContext _context;
    public ProductService(ApplicationDbContext dbContext)
    {
        _context = dbContext;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public Task<Product> CreateProductAsync(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteProductAsync(int productId)
    {
        throw new NotImplementedException();
    }

    public Product GetProductById(int productId)
    {
        return _context.Products.FirstOrDefault(x => x.ProductID == productId);
    }

    public Task<Product> UpdateProductAsync(int productId, Product product)
    {
        throw new NotImplementedException();
    }
}