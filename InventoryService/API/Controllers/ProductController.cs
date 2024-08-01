using InventoryService.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.API.Controllers 
{ 
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IProductService productService) : ControllerBase
    { 
        private readonly IProductService _productService = productService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(){
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }
        
    }
}
