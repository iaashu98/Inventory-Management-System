using InventoryService.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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
            IEnumerable<Product> products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Product>> GetProductByIdAsync(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid product ID");
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
                return NotFound($"The Product with Product ID {id} is Not Found.");
            return product;
        }

        [HttpGet("{name:alpha}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByName(string name)
        {
            if(string.IsNullOrEmpty(name)){
                return BadRequest("This is a Bad Request.");
            }
            List<Product> products = await _productService.GetProductByNameAsync(name);
            if(products.IsNullOrEmpty())
                return NotFound($"The Product with Product Name {name} is Not Found.");
            return products;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddProductAsync(Product product)
        {
            if(product == null)
                return BadRequest("This is a Bad Request.");
            Product savedProduct = await _productService.CreateProductAsync(product);
            return savedProduct;
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteProductAsync(int productId)
        {
            if(productId < 0)
                return BadRequest("Invalid product ID");

            bool result = await _productService.DeleteProductAsync(productId);
            return result;
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Product>> UpdateProductAsync(int id, Product product)
        {
            if(id < 0)
                return BadRequest("Invalid product ID");
            Product updatedProduct = await _productService.UpdateProductAsync(product);
            if (updatedProduct == null)
                return NotFound($"The Product with Product ID {id} is Not Found.");
            return updatedProduct;
        }
    }
}
