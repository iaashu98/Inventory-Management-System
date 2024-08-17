using InventoryService.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

public class SupplierService : ISupplierService
{
    private readonly ApplicationDbContext _applicationDbContext;
    public SupplierService(ApplicationDbContext dbContext)
    {
        _applicationDbContext = dbContext;
    }

    public async Task<IEnumerable<Supplier>> GetAllSupplierAsync()
    {
        return await _applicationDbContext.Suppliers.ToListAsync();
    }

    public Task<Supplier> CreateSupplierAsync(Supplier supplier)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteSupplierAsync(int supplierId)
    {
        throw new NotImplementedException();
    }

    public Task<Supplier> GetSupplierByIdAsync(int supplierId)
    {
        throw new NotImplementedException();
    }

    public Task<Supplier> UpdateSupplierAsync(int supplierId, Supplier supplier)
    {
        throw new NotImplementedException();
    }
}