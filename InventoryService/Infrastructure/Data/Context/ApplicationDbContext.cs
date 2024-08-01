using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductDetail> ProductDetails { get; set; }
    public DbSet<ProductInventory> ProductInventories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Enable detailed logging
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        
        // Ensure the connection string is set
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=aspnet-WebApplica71d622;User Id=SA;Password=Password123$;Encrypt=False;TrustServerCertificate=True;");
        }

        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().ToTable("Categories").HasKey(c => c.CategoryID);

        modelBuilder.Entity<Supplier>().ToTable("Suppliers").HasKey(c => c.SupplierID);

        modelBuilder.Entity<Product>().ToTable("Products").HasKey(c => c.ProductID);
        //realtionship bw Products and Categories 1-to-Many
        modelBuilder.Entity<Product>().HasOne(p => p.Category)
                                      .WithMany(c => c.Products)
                                      .HasForeignKey( d=> d.CategoryID);

        //realtionship bw Products and Suppliers 1-to-Many
        modelBuilder.Entity<Product>().HasOne(p => p.Supplier)
                                      .WithMany(c => c.Products)
                                      .HasForeignKey( d=> d.SupplierID);

        modelBuilder.Entity<ProductDetail>().ToTable("ProductDetails").HasKey(c => c.ProductDetailID);
        //realtionship bw ProductDetails and Products 1-to-1
        modelBuilder.Entity<ProductDetail>().HasOne(pd => pd.Product)
                                            .WithOne(c => c.ProductDetail)
                                            .HasForeignKey<ProductDetail>(d => d.ProductID);

        modelBuilder.Entity<ProductInventory>().ToTable("ProductInventory").HasKey(c => c.InventoryID);
        //realtionship bw ProductInventory and Products 1-to-Many
        modelBuilder.Entity<ProductInventory>().HasOne(pi => pi.Product)
                                               .WithMany(c => c.ProductInventories)
                                               .HasForeignKey(d => d.ProductID);

                                               // Specify column type or precision for decimal properties
        modelBuilder.Entity<Product>()
            .Property(p => p.UnitPrice)
            .HasColumnType("decimal(18,2)");
    }
}
