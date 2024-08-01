namespace InventoryService.Domain.Interfaces
{
    public interface IProductDetailService{
        Task<IEnumerable<ProductDetail>> GetAllProductDetailsAsync();
        Task<ProductDetail> GetProductDetailByIdAsync(int productDetailId);
        Task<ProductDetail> CreateProductDetailAsync(ProductDetail productDetail);
        Task<ProductDetail> UpdateProductDetailAsync(int productDetailId, ProductDetail productDetail);
        Task<bool> DeleteProductDetailAsync(int productDetailId);
    }
}