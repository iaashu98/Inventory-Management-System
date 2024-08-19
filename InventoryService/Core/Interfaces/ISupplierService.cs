namespace InventoryService.Core.Interfaces
{
    public interface ISupplierService{
        Task<IEnumerable<Supplier>> GetAllSupplierAsync();
        Task<Supplier> GetSupplierByIdAsync(int supplierId);
        Task<Supplier> CreateSupplierAsync(Supplier supplier);
        Task<Supplier> UpdateSupplierAsync(int supplierId, Supplier supplier);
        Task<int> DeleteSupplierAsync(int supplierId);
        Task<IEnumerable<Supplier>> SearchSuppliersAsync(string searchText);
    }
}