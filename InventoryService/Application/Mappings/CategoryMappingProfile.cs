using AutoMapper;
using InventoryService.Core.DTOs.CategoryDTOs;

namespace InventoryService.Application.Mappings
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<Category, CreateCategoryDTO>();
            CreateMap<CreateCategoryDTO, Category>();
        }
    }
}