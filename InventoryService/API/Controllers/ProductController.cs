using InventoryService.Core.Interfaces;
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
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            IEnumerable<Product> products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Product>> GetProductById(int id)
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
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            if(product == null)
                return BadRequest("This is a Bad Request.");
            return await _productService.CreateProductAsync(product);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteProduct(int productId)
        {
            if(productId < 0)
                return BadRequest("Invalid product ID");

            return await _productService.DeleteProductAsync(productId);
        }

        [HttpPut]
        public async Task<ActionResult<Product>> UpdateProduct(int id, Product product)
        {
            if(id < 0)
                return BadRequest("Invalid product ID");
            Product updatedProduct = await _productService.UpdateProductAsync(product);
            if (updatedProduct == null)
                return NotFound($"The Product with Product ID {id} is Not Found.");
            return updatedProduct;
        }

        [HttpGet("[action]/{searchText:alpha}")]
        public async Task<ActionResult<IEnumerable<Product>>> SearchProducts(string searchText){
            IEnumerable<Product> products = await _productService.SearchProductsAsync(searchText);
            return Ok(products);
        }
    }
}
