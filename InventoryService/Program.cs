using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using InventoryService.Core.Interfaces;
using InventoryService.Application.Validators.ProductValidator;
using InventoryService.Application.Validators.ProductInventoryValidator;
using InventoryService.Application.Validators.CategoryValidator;
using InventoryService.Application.Validators;
using InventoryService.Application.Services;

var builder = WebApplication.CreateBuilder(args);
//Connection string
string connString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the DI container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<ApplicationDbContext>();

//Regsiter Services
builder.Services.AddScoped<ProductValidator>();
builder.Services.AddScoped<CategoryValidator>();
builder.Services.AddScoped<SupplierValidator>();
builder.Services.AddScoped<ProductDetailValidator>();
builder.Services.AddScoped<ProductInventoryValidator>();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<IProductInventoryService, ProductInventoryService>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:5000")
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("AllowSpecificOrigin");

app.MapControllers();

app.Run();
