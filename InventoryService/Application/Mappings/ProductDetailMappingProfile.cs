using AutoMapper;
using InventoryService.Core.DTOs.ProductDetailDTOs;

namespace InventoryService.Application.Mappings
{
    public class ProductDetailMappingProfile : Profile
    {
        public ProductDetailMappingProfile()
        {
            CreateMap<ProductDetail, ProductDetailDTO>();
            CreateMap<ProductDetailDTO, ProductDetail>();
            CreateMap<ProductDetail, CreateProductDetailDTO>();
            CreateMap<CreateProductDetailDTO, ProductDetail>();
        }
    }
}