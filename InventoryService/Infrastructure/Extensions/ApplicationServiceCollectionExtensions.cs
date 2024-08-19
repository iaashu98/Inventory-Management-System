using InventoryService.Application.Services;
using InventoryService.Core.Interfaces;

namespace InventoryService.Infrastructure.Extensions
{
    public static class ApplicationServiceCollectionExtensions{
        public static IServiceCollection AddApplicationServices(this IServiceCollection services){
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductDetailService, ProductDetailService>();
            services.AddScoped<IProductInventoryService, ProductInventoryService>();

            return services;
        }
    }
}