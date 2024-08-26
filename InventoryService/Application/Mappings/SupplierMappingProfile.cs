using AutoMapper;
using InventoryService.Core.DTOs.SupplierDTOs;

namespace InventoryService.Application.Mappings
{
    public class SupplierMappingProfile : Profile{
        public SupplierMappingProfile()
        {
            CreateMap<Supplier, SupplierDTO>().ReverseMap();
            CreateMap<Supplier, CreateSupplierDTO>().ReverseMap();
        }
    }
}