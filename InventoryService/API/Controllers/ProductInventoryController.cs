using AutoMapper;
using InventoryService.Core.DTOs.ProductInventoryDTOs;
using InventoryService.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductinventoriesController(IProductInventoryService inventoryService, IMapper mapper) : ControllerBase
    {
        private readonly IProductInventoryService _productInventoryService = inventoryService;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductInventoryDTO>>> GetAllProductInventory()
        {
            IEnumerable<ProductInventory> inventories = await _productInventoryService.GetAllProductInventoryAsync();
            return _mapper.Map<IEnumerable<ProductInventoryDTO>>(inventories).ToList();
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<ProductInventoryDTO>> GetProductInventoryById(int Id)
        {
            ProductInventory inventory = await _productInventoryService.GetProductInventoryByIdAsync(Id);
            return _mapper.Map<ProductInventoryDTO>(inventory);
        }

        [HttpPost]
        public async Task<ActionResult<ProductInventoryDTO>> AddProductInventory(CreateProductInventoryDTO productInventoryDTO)
        {
            ProductInventory productInventory = _mapper.Map<ProductInventory>(productInventoryDTO);
            ProductInventory createdInventory = await _productInventoryService.CreateProductInventoryAsync(productInventory);
            return _mapper.Map<ProductInventoryDTO>(createdInventory);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<ProductInventoryDTO>> UpdateProductInventory(ProductInventoryDTO productInventoryDTO, int Id)
        {
            ProductInventory productInventory = _mapper.Map<ProductInventory>(productInventoryDTO);
            ProductInventory updatedInventory = await _productInventoryService.UpdateProductInventoryAsync(Id, productInventory);
            return _mapper.Map<ProductInventoryDTO>(updatedInventory);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<int>> DeleteProductInventory(int Id)
        {
            int deletedId = await _productInventoryService.DeleteProductInventoryAsync(Id);
            return deletedId;
        }
    }
}