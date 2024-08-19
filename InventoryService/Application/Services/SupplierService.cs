using InventoryService.Application.Validators;
using InventoryService.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Application.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ApplicationDbContext _context;
        private readonly SupplierValidator _supplierValidator;

        public SupplierService(ApplicationDbContext dbContext, SupplierValidator validator)
        {
            _context = dbContext;
            _supplierValidator = validator;
        }

        public async Task<IEnumerable<Supplier>> GetAllSupplierAsync()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public async Task<Supplier> CreateSupplierAsync(Supplier supplier)
        {
            var result = _supplierValidator.ValidateSupplier(supplier);
            if (!result.IsValid)
            {
                var errorMessage = string.Join(", ", result.Errors);
                throw new ArgumentException($"Invalid supplier data: {errorMessage}");
            }

            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }

        public async Task<int> DeleteSupplierAsync(int supplierId)
        {
            Supplier existingSupplier = await GetSupplierByIdAsync(supplierId);
            _context.Suppliers.Remove(existingSupplier);
            await _context.SaveChangesAsync();
            return supplierId;
        }

        public async Task<Supplier> GetSupplierByIdAsync(int supplierId)
        {
            return await _context.Suppliers.FirstOrDefaultAsync(x => x.SupplierID == supplierId);
        }

        public async Task<Supplier> UpdateSupplierAsync(int supplierId, Supplier supplier)
        {
            var result = _supplierValidator.ValidateSupplier(supplier);
            if (!result.IsValid)
            {
                var errorMessage = string.Join(", ", result.Errors);
                throw new ArgumentException($"Invalid supplier data: {errorMessage}");
            }

            Supplier existingSupplier = await GetSupplierByIdAsync(supplierId);
            _context.Suppliers.Entry(existingSupplier).CurrentValues.SetValues(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }

        public async Task<IEnumerable<Supplier>> SearchSuppliersAsync(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
                return [];

            return await _context.Suppliers.Where(x => x.SupplierName.Contains(searchText)).ToListAsync();
        }
    }
}