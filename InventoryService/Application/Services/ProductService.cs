using InventoryService.Domain.Interfaces;

public class ProductService: IProductService{
    private readonly ApplicationDbContext _context;

    public Task<Product> CreateProductAsync(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetProductByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}