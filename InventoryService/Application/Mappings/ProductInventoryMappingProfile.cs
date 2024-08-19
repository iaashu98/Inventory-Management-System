using AutoMapper;
using InventoryService.Core.DTOs;

namespace InventoryService.Application.Mappings
{
    public class ProductInventoryMappingProfile : Profile
    {
        public ProductInventoryMappingProfile()
        {
            CreateMap<ProductInventory, ProductInventoryDTO>().ReverseMap();
        }
    }
}