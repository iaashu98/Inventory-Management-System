using AutoMapper;
using InventoryService.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductDetailController(IProductDetailService productDetailService, IMapper mapper) : ControllerBase
    {
        private readonly IProductDetailService _productDetailService = productDetailService;
        private readonly IMapper _mapper = mapper;

        [HttpPost]
        public async Task<ProductDetail> AddProductDetail(ProductDetail productDetail)
        {
            return await _productDetailService.CreateProductDetailAsync(productDetail);
        }

        [HttpDelete]
        public async Task<int> DeleteProductDetail(int productDetailId)
        {
            return await _productDetailService.DeleteProductDetailAsync(productDetailId);
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDetail>> GetAllProductDetails()
        {
            return await _productDetailService.GetAllProductDetailsAsync();
        }

        [HttpGet("{productDetailId:int}")]
        public async Task<ProductDetail> GetProductDetailById(int productDetailId)
        {
            return await _productDetailService.GetProductDetailByIdAsync(productDetailId);
        }

        [HttpGet("[action]/{searchText:alpha}")]
        public async Task<IEnumerable<ProductDetail>> SearchProductDetails(string searchText)
        {
            return await _productDetailService.SearchProductDetailsAsync(searchText);
        }

        [HttpPut]
        public async Task<ProductDetail> UpdateProductDetail(int productDetailId, ProductDetail productDetail)
        {
            return await _productDetailService.UpdateProductDetailAsync(productDetailId, productDetail);
        }
    }
}