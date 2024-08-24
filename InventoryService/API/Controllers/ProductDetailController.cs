using AutoMapper;
using InventoryService.Core.DTOs;
using InventoryService.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace InventoryService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductDetailController(IProductDetailService productDetailService, IMapper mapper) : ControllerBase
    {
        private readonly IProductDetailService _productDetailService = productDetailService;
        private readonly IMapper _mapper = mapper;

        [HttpPost]
        public async Task<ProductDetailDTO> AddProductDetail(ProductDetailDTO productDetailDTO)
        {
            ProductDetail productDetail = _mapper.Map<ProductDetail>(productDetailDTO);
            ProductDetail createdProductDetail = await _productDetailService.CreateProductDetailAsync(productDetail);
            ProductDetailDTO createdProductDetailDTO = _mapper.Map<ProductDetailDTO>(createdProductDetail);
            return createdProductDetailDTO;
        }

        [HttpDelete]
        public async Task<int> DeleteProductDetail(int productDetailId)
        {
            return await _productDetailService.DeleteProductDetailAsync(productDetailId);
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDetailDTO>> GetAllProductDetails()
        {
            IEnumerable<ProductDetail> productDetails = await _productDetailService.GetAllProductDetailsAsync();
            return _mapper.Map<IEnumerable<ProductDetailDTO>>(productDetails).ToList();
        }

        [HttpGet("{productDetailId:int}")]
        public async Task<ProductDetailDTO> GetProductDetailById(int productDetailId)
        {
            ProductDetail productDetail = await _productDetailService.GetProductDetailByIdAsync(productDetailId);
            return _mapper.Map<ProductDetailDTO>(productDetail);
        }

        [HttpGet("[action]/{searchText:alpha}")]
        public async Task<IEnumerable<ProductDetailDTO>> SearchProductDetails(string searchText)
        {
            IEnumerable<ProductDetail> productDetails = await _productDetailService.SearchProductDetailsAsync(searchText);
            return _mapper.Map<IEnumerable<ProductDetailDTO>>(productDetails);
        }

        [HttpPut]
        public async Task<ProductDetailDTO> UpdateProductDetail(int productDetailId, ProductDetailDTO productDetailDTO)
        {
            ProductDetail productDetail = _mapper.Map<ProductDetail>(productDetailDTO);
            ProductDetail updatedProductDetail = await _productDetailService.UpdateProductDetailAsync(productDetailId, productDetail);
            return _mapper.Map<ProductDetailDTO>(updatedProductDetail);
        }
    }
}