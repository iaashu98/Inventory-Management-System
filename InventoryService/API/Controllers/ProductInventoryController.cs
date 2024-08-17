using InventoryService.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductInventoryController(IProductInventoryService inventoryService) : ControllerBase {
        private readonly IProductInventoryService _productInventoryService = inventoryService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductInventory>>> GetAllProductInventory(){
            IEnumerable<ProductInventory> inventories = await _productInventoryService.GetAllProductInventoryAsync();
            return Ok(inventories);
        }
        
        [HttpGet("{Id:int}")]
        public async Task<ActionResult<ProductInventory>> GetProductInventoryById(int Id){
            ProductInventory inventory = await _productInventoryService.GetProductInventoryByIdAsync(Id);
            return inventory;
        }

        [HttpPost]
        public async Task<ActionResult<ProductInventory>> AddProductInventory(ProductInventory productInventory){
            ProductInventory inventory = await _productInventoryService.CreateProductInventoryAsync(productInventory);
            return inventory;
        }

        [HttpPut("{Id:int}")]
        public async Task<ActionResult<ProductInventory>> UpdateProductInventory(ProductInventory productInventory, int Id){
            ProductInventory inventory = await _productInventoryService.UpdateProductInventoryAsync(Id, productInventory);
            return inventory;
        }

        [HttpDelete]
        public async Task<ActionResult<int>> DeleteProductInventory(int Id){
            int deletedId = await _productInventoryService.DeleteProductInventoryAsync(Id); 
            return deletedId;
        }
    }
}