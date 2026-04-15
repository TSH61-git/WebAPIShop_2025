using DTOs;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase, IProductController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDTO productDto)
        {
            var created = await _productService.AddProductAsync(productDto);
            return CreatedAtAction(nameof(GetProductById),
                new { id = created.ProductId }, created);
        }

        // GET: api/<ValuesController>
        [HttpGet]
        async public Task<ActionResult<PageResponseDTO<ProductDTO>>> Get(int position, int skip, [FromQuery] ProductSearchParams parameters)
        {
            PageResponseDTO<ProductDTO> pageResponse = await _productService.GetProducts(position, skip, parameters);
            return Ok(pageResponse);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }


    }
}
