using DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApiShop.Controllers
{
    public interface IOrderController
    {
        void Delete(int id);
        IEnumerable<string> Get();
        string Get(int id);
        Task<ActionResult<IEnumerable<OrderReadDTO>>> GetUserOrders(int userId);
        Task<ActionResult<OrderReadDTO>> Post([FromBody] OrderCreateDTO order);
        void Put(int id, [FromBody] string value);
    }
}