using AutoMapper;
using InventoryService.Core.DTOs;

namespace InventoryService.Application.Mappings
{
    public class SupplierMappingProfile : Profile{
        public SupplierMappingProfile()
        {
            CreateMap<Supplier, SupplierDTO>();
            CreateMap<SupplierDTO, Supplier>();
        }
    }
}