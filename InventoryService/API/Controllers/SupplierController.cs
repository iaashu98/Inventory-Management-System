using AutoMapper;
using InventoryService.Core.DTOs.SupplierDTOs;
using InventoryService.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuppliersController(ISupplierService supplierService, IMapper mapper) : ControllerBase
    {
        private readonly ISupplierService _supplierService = supplierService;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupplierDTO>>> GetAllSuppliers()
        {
            IEnumerable<Supplier> suppliers = await _supplierService.GetAllSupplierAsync();
            return _mapper.Map<IEnumerable<SupplierDTO>>(suppliers).ToList();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SupplierDTO>> GetSupplierById(int id)
        { 
            Supplier supplier = await _supplierService.GetSupplierByIdAsync(id);
            return _mapper.Map<SupplierDTO>(supplier);
        }

        [HttpPost]
        public async Task<ActionResult<SupplierDTO>> AddSupplier(CreateSupplierDTO supplierDTO)
        {
            Supplier supplier = _mapper.Map<Supplier>(supplierDTO);
            Supplier createdSupplier = await _supplierService.CreateSupplierAsync(supplier);
            return _mapper.Map<SupplierDTO>(createdSupplier);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<SupplierDTO>> UpdateSupplier(int id, SupplierDTO supplierDTO)
        {
            Supplier supplier = _mapper.Map<Supplier>(supplierDTO);
            Supplier updatedSupplier = await _supplierService.UpdateSupplierAsync(id, supplier);
            return _mapper.Map<SupplierDTO>(updatedSupplier);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<int>> DeleteSupplierById(int id)
        {
            return Ok(await _supplierService.DeleteSupplierAsync(id));
        }

        [HttpGet("[action]/{searchText:alpha}")]
        public async Task<ActionResult<IEnumerable<SupplierDTO>>> Search(string searchText)
        {
            IEnumerable<Supplier> suppliers = await _supplierService.SearchSuppliersAsync(searchText);
            return _mapper.Map<IEnumerable<SupplierDTO>>(suppliers).ToList();
        }
    }
}