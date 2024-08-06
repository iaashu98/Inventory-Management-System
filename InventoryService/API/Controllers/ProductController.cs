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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Product> GetProductById(int id)
        {
            if (id <= 0)
                return BadRequest("This is a Bad Request.");
            var product = _productService.GetProductById(id);
            if (product == null)
                return NotFound($"The Product with Product ID {id} is Not Found.");
            return product;
        }
    }
}
