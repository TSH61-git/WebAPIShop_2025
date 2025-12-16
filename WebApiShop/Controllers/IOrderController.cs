using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApiShop.Controllers
{
    public interface IOrderController
    {
        void Delete(int id);
        IEnumerable<string> Get();
        string Get(int id);
        Task<ActionResult<Order>> Post([FromBody] Order order);
        void Put(int id, [FromBody] string value);
    }
}