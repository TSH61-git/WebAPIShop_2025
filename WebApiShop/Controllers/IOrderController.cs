using DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApiShop.Controllers
{
    public interface IOrderController
    {
        Task<ActionResult<OrderReadDTO>> GetOrderByID(int id);
        Task<IActionResult> GetAllOrders();
        Task<ActionResult<IEnumerable<OrderReadDTO>>> GetUserOrders(int userId);
        Task<ActionResult<OrderReadDTO>> Post([FromBody] OrderCreateDTO order);
        Task<IActionResult> Put(int id, [FromBody] ChangeOrderStatusDto dto);
    }
}