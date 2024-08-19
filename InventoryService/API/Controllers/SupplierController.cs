using InventoryService.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController(ISupplierService supplierService) : ControllerBase
    {
        private readonly ISupplierService _supplierService = supplierService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetAllSuppliers()
        {
            IEnumerable<Supplier> suppliers = await _supplierService.GetAllSupplierAsync();
            return suppliers.ToList();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Supplier>> GetSupplierById(int id)
        {
            return await _supplierService.GetSupplierByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<Supplier>> AddSupplier(Supplier supplier)
        {
            return await _supplierService.CreateSupplierAsync(supplier);
        }

        [HttpPut]
        public async Task<ActionResult<Supplier>> UpdateSupplier(int id, Supplier supplier)
        {
            return await _supplierService.UpdateSupplierAsync(id, supplier);
        }

        [HttpDelete]
        public async Task<ActionResult<int>> DeleteSupplierById(int id)
        {
            return Ok(await _supplierService.DeleteSupplierAsync(id));
        }

        [HttpGet("[action]/{searchText:alpha}")]
        public async Task<ActionResult<IEnumerable<Supplier>>> SearchSuppliers(string searchText)
        {
            return Ok(await _supplierService.SearchSuppliersAsync(searchText));
        }
    }
}