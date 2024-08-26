using AutoMapper;
using InventoryService.Core.DTOs.ProductDTOs;

namespace InventoryService.Application.Mappings
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();
            CreateMap<Product, CreateProductDTO>().ReverseMap();
        }
    }
}