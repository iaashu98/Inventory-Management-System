using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using InventoryService.Application.Mappings;
using InventoryService.Infrastructure.Extensions;

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
