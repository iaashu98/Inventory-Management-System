using AutoMapper;
using InventoryService.Core.DTOs;
using InventoryService.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace InventoryService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IProductService productService, IMapper mapper) : ControllerBase
    {
        private readonly IProductService _productService = productService;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts()
        {
            IEnumerable<Product> products = await _productService.GetAllProductsAsync();
            IEnumerable<ProductDTO> productDTOs = _mapper.Map<IEnumerable<ProductDTO>>(products);

            return Ok(productDTOs);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid product ID");

            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
                return NotFound($"The Product with Product ID {id} is Not Found.");

            ProductDTO productDTO = _mapper.Map<ProductDTO>(product);

            return productDTO;
        }

        [HttpGet("{name:alpha}")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("This is a Bad Request.");
            }
            List<Product> products = await _productService.GetProductByNameAsync(name);
            List<ProductDTO> productDTOs = _mapper.Map<List<ProductDTO>>(products);

            if (productDTOs.IsNullOrEmpty())
                return NotFound($"The Product with Product Name {name} is Not Found.");

            return productDTOs;
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> AddProduct(ProductDTO productDTO)
        {
            if (productDTO == null)
                return BadRequest("This is a Bad Request.");
            Product product = _mapper.Map<Product>(productDTO);
            Product createdProduct = await _productService.CreateProductAsync(product);
            ProductDTO createdProductDTO = _mapper.Map<ProductDTO>(createdProduct);
            return createdProductDTO;
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteProduct(int productId)
        {
            if (productId < 0)
                return BadRequest("Invalid product ID");

            return await _productService.DeleteProductAsync(productId);
        }

        [HttpPut]
        public async Task<ActionResult<ProductDTO>> UpdateProduct(int id, ProductDTO productDTO)
        {
            if (id != productDTO.ProductID || id < 0)
                return BadRequest("Invalid product ID");

            Product product = _mapper.Map<Product>(productDTO);
            Product updatedProduct = await _productService.UpdateProductAsync(product);

            if (updatedProduct == null)
                return NotFound($"The Product with Product ID {id} is Not Found.");

            ProductDTO updatedProductDTO = _mapper.Map<ProductDTO>(updatedProduct);

            return updatedProductDTO;
        }

        [HttpGet("[action]/{searchText:alpha}")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> SearchProducts(string searchText)
        {
            IEnumerable<Product> products = await _productService.SearchProductsAsync(searchText);
            IEnumerable<ProductDTO> productDTOs = _mapper.Map<IEnumerable<ProductDTO>>(products);

            return Ok(productDTOs);
        }
    }
}
