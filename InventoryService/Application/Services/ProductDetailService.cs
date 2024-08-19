using InventoryService.Application.Validators;
using InventoryService.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Application.Services
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly ApplicationDbContext _context;
        private readonly ProductDetailValidator _validator;
        public ProductDetailService(ApplicationDbContext dbContext, ProductDetailValidator productDetailValidator)
        {
            _context = dbContext;
            _validator = productDetailValidator;
        }

        public async Task<ProductDetail> CreateProductDetailAsync(ProductDetail productDetail)
        {
            var result = _validator.ValidateProductDetail(productDetail);
            if (!result.IsValid)
            {
                var errorMessage = string.Join(", ", result.Errors);
                throw new ArgumentException($"Invalid product detail data: {errorMessage}");
            }

            _context.ProductDetails.Add(productDetail);
            await _context.SaveChangesAsync();
            return productDetail;
        }

        public async Task<int> DeleteProductDetailAsync(int productDetailId)
        {
            ProductDetail existingProductDetails = await GetProductDetailByIdAsync(productDetailId);
            _context.ProductDetails.Remove(existingProductDetails);
            await _context.SaveChangesAsync();
            return productDetailId;
        }

        public async Task<IEnumerable<ProductDetail>> GetAllProductDetailsAsync()
        {
            return await _context.ProductDetails.ToListAsync();
        }

        public async Task<ProductDetail> GetProductDetailByIdAsync(int productDetailId)
        {
            return await _context.ProductDetails.FirstOrDefaultAsync(x => x.ProductDetailID == productDetailId);
        }

        public async Task<IEnumerable<ProductDetail>> SearchProductDetailsAsync(string searchText)
        {
            return await _context.ProductDetails.Where(
                            x => x.Description.Contains(searchText)
                            || x.Manufacturer.Contains(searchText)
                            || x.Specifications.Contains(searchText)).ToListAsync();
        }

        public async Task<ProductDetail> UpdateProductDetailAsync(int productDetailId, ProductDetail productDetail)
        {
            var result = _validator.ValidateProductDetail(productDetail);
            if (!result.IsValid)
            {
                var errorMessage = string.Join(", ", result.Errors);
                throw new ArgumentException($"Invalid product detail data: {errorMessage}");
            }

            ProductDetail existingProductDetail = await GetProductDetailByIdAsync(productDetailId);

            _context.ProductDetails.Entry(existingProductDetail).CurrentValues.SetValues(productDetail);
            await _context.SaveChangesAsync();
            return productDetail;
        }
    }
}