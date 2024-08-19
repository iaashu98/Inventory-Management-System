namespace InventoryService.Core.Interfaces
{
    public interface IProductDetailService{
        Task<IEnumerable<ProductDetail>> GetAllProductDetailsAsync();
        Task<ProductDetail> GetProductDetailByIdAsync(int productDetailId);
        Task<ProductDetail> CreateProductDetailAsync(ProductDetail productDetail);
        Task<ProductDetail> UpdateProductDetailAsync(int productDetailId, ProductDetail productDetail);
        Task<int> DeleteProductDetailAsync(int productDetailId);
        Task<IEnumerable<ProductDetail>> SearchProductDetailsAsync(string searchText);
    }
}