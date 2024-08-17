using InventoryService.Application.Validators.ProductValidator;
using InventoryService.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

public class ProductService: IProductService{
    private readonly ApplicationDbContext _context;
    private readonly ProductValidator _productValidator;

    public ProductService(ApplicationDbContext dbContext, ProductValidator validator)
    {
        _context = dbContext;
        _productValidator = validator;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product> CreateProductAsync(Product product)
    {
        var validationResult = _productValidator.ValidateProduct(product);
        if(!validationResult.IsValid){
            var errorMessage = string.Join(", ", validationResult.Errors);
            throw new ArgumentException($"Invalid product data: {errorMessage}");
        }
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> UpdateProductAsync(Product product)
    {
        var validationResult = _productValidator.ValidateProduct(product);
        if(!validationResult.IsValid){
            var errorMessage = string.Join(", ", validationResult.Errors);
            throw new ArgumentException($"Invalid product data: {errorMessage}");
        }

        Product existingProduct = await GetProductByIdAsync(product.ProductID);

        _context.Entry(existingProduct).CurrentValues.SetValues(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<bool> DeleteProductAsync(int productId)
    {
        Product product = await GetProductByIdAsync(productId);
        if(product == null)
            return false;
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Product> GetProductByIdAsync(int productId)
    {
        return await _context.Products.FirstOrDefaultAsync(x => x.ProductID == productId);
    }

    public async Task<List<Product>> GetProductByNameAsync(string productName)
    {
        if(string.IsNullOrWhiteSpace(productName))
            return [];

        return await _context.Products.Where(x=> x.ProductName == productName).ToListAsync();
    }

    public async Task<IEnumerable<Product>> SearchProductsAsync(string searchText)
    {
        if(string.IsNullOrWhiteSpace(searchText))
            return [];

        return await _context.Products.Where(x => x.ProductName.Contains(searchText)).ToListAsync();
    }
}