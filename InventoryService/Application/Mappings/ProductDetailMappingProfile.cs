using AutoMapper;
using InventoryService.Core.DTOs;

namespace InventoryService.Application.Mappings
{
    public class ProductDetailMappingProfile : Profile
    {
        public ProductDetailMappingProfile()
        {
            CreateMap<ProductDetail, ProductDetailDTO>();
            CreateMap<ProductDetailDTO, ProductDetail>();
        }
    }
}