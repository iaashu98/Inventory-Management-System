using InventoryService.Application.Validators;

namespace InventoryService.Infrastructure.Extensions
{
    public static class ValidatorServiceCollectionExtensions
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddScoped<ProductValidator>();
            services.AddScoped<CategoryValidator>();
            services.AddScoped<SupplierValidator>();
            services.AddScoped<ProductDetailValidator>();
            services.AddScoped<ProductInventoryValidator>();

            return services;
        }
    }
}