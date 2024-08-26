using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using InventoryService.Application.Mappings;
using InventoryService.Infrastructure.Extensions;
using MediatR;
using FluentValidation;
using InventoryService.Application.Behaviors;
using InventoryService.Core.DTOs.SupplierDTOs;
using InventoryService.Application.Validators.DTOValidators.SupplierDtoValidator;
using System.Reflection;
using InventoryService.Application.Validators.DtoValidators.ProductDtoValidator;

var builder = WebApplication.CreateBuilder(args);

//Connection string
string connString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the DI container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<ApplicationDbContext>();

// Regsiter all validators - Added a custom extension method to register all the validators
builder.Services.AddValidators();

// Regsiter all services - Added a custom extension method to register all the services 
builder.Services.AddApplicationServices();

// Register all mapping profiles
builder.Services.AddAutoMapper(typeof(ProductMappingProfile),
                               typeof(CategoryMappingProfile),
                               typeof(ProductDetailMappingProfile),
                               typeof(ProductInventoryMappingProfile),
                               typeof(SupplierMappingProfile));


// Add MediatR and FluentValidation services
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddValidatorsFromAssemblyContaining<CreateSupplierDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<ProductDtoValidator>();

// Register the ValidationBehavior
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Connect it to Frontend project
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://127.0.0.1:3000", "http://localhost:3000") 
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
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

app.UseCors("AllowFrontend");

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
