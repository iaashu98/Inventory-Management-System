
using InventoryService.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

public class ProductInventoryService: IProductInventoryService{
    private readonly ApplicationDbContext _context;
    public ProductInventoryService(ApplicationDbContext dbContext)
    {
        _context = dbContext;
    }

    public async Task<IEnumerable<ProductInventory>> GetAllProductInventoryAsync()
    {
        return await _context.ProductInventories.ToListAsync();
    }
    public Task<ProductInventory> CreateProductInventoryAsync(ProductInventory productInventory)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteProductInventoryAsync(int productInventoryId)
    {
        throw new NotImplementedException();
    }

    public Task<ProductInventory> GetProductInventoryByIdAsync(int productInventoryId)
    {
        throw new NotImplementedException();
    }

    public Task<ProductInventory> UpdateProductInventoryAsync(int productInventoryId, ProductInventory productInventory)
    {
        throw new NotImplementedException();
    }
}