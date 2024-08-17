using InventoryService.Application.Validators.ProductInventoryValidator;
using InventoryService.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

public class ProductInventoryService: IProductInventoryService{
    private readonly ApplicationDbContext _context;
    private readonly ProductInventoryValidator _inventoryValidator;
    public ProductInventoryService(ApplicationDbContext dbContext, ProductInventoryValidator validator)
    {
        _context = dbContext;
        _inventoryValidator = validator;
    }

    public async Task<IEnumerable<ProductInventory>> GetAllProductInventoryAsync()
    {
        return await _context.ProductInventories.ToListAsync();
    }

    public async Task<ProductInventory> CreateProductInventoryAsync(ProductInventory productInventory)
    {
        var validationResult = _inventoryValidator.ValidateInventory(productInventory);
        if(!validationResult.IsValid){
            var errorMessage = string.Join(", ", validationResult.Errors);
            throw new ArgumentException($"Invalid inventory data: {errorMessage}");
        }

        _context.ProductInventories.Add(productInventory);
        await _context.SaveChangesAsync();
        return productInventory;
    }

    public async Task<int> DeleteProductInventoryAsync(int productInventoryId)
    {
        ProductInventory inventory = await GetProductInventoryByIdAsync(productInventoryId);
        if(inventory == null)
            return 0;
        _context.ProductInventories.Remove(inventory);
        await _context.SaveChangesAsync();
        return productInventoryId;
    }

    public async Task<ProductInventory> GetProductInventoryByIdAsync(int productInventoryId)
    {
        ProductInventory inventory = await _context.ProductInventories.FirstOrDefaultAsync(x => x.InventoryID == productInventoryId);
        return inventory;
    }

    public async Task<ProductInventory> UpdateProductInventoryAsync(int productInventoryId, ProductInventory productInventory)
    {
        var validationResult = _inventoryValidator.ValidateInventory(productInventory);
        if(!validationResult.IsValid){
            var errorMessage = string.Join(", ", validationResult.Errors);
            throw new ArgumentException($"Invalid inventory data: {errorMessage}");
        }

        ProductInventory existingInventory = await GetProductInventoryByIdAsync(productInventoryId);
        _context.Entry(existingInventory).CurrentValues.SetValues(productInventory);
        await _context.SaveChangesAsync();
        return productInventory;
    }
}