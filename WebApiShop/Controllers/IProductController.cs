using DTOs;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApiShop.Controllers
{
    public interface IProductController
    {
        void Delete(int id);
        Task<ActionResult<PageResponseDTO<ProductDTO>>> Get(int position, int skip, [FromQuery] ProductSearchParams parameters);
        string Get(int id);
        void Post([FromBody] string value);
        void Put(int id, [FromBody] string value);
    }
}