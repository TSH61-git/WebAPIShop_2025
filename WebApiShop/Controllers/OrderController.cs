using DTOs;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase, IOrderController
    {

        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }


        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<OrderReadDTO>>> GetUserOrders(int userId)
        {
            var orders = await _orderService.GetOrdersByUserIdAsync(userId);

            if (orders == null || !orders.Any())
                return NotFound(new { Message = $"No orders found for user {userId}" });

            return Ok(orders);
        }

        // POST api/<OrderController>
        [HttpPost]
        async public Task<ActionResult<OrderReadDTO>> Post([FromBody] OrderCreateDTO order)
        {
            var newOrder = await _orderService.addOrder(order);
            if (newOrder == null)
                return BadRequest();
            return CreatedAtAction(nameof(Get), new { id = newOrder.OrderId }, newOrder);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
