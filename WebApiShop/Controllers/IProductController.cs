using DTOs;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApiShop.Controllers
{
    public interface IProductController
    {
        Task<IActionResult> CreateProduct([FromBody] ProductDTO productDto);
        Task<ActionResult<PageResponseDTO<ProductDTO>>> Get(int position, int skip, [FromQuery] ProductSearchParams parameters);
        Task<IActionResult> GetProductById(int id);
    }
}