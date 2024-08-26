using AutoMapper;
using InventoryService.Core.DTOs.ProductInventoryDTOs;

namespace InventoryService.Application.Mappings
{
    public class ProductInventoryMappingProfile : Profile
    {
        public ProductInventoryMappingProfile()
        {
            CreateMap<ProductInventory, ProductInventoryDTO>().ReverseMap();
            CreateMap<ProductInventory, CreateProductInventoryDTO>().ReverseMap();
        }
    }
}