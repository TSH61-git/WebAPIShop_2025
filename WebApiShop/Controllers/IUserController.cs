using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIShop.Controllers
{
    public interface IUserController
    {
        void Delete(int id);
        IEnumerable<string> Get();
        ActionResult<User> Get(int id);
        ActionResult<User> Login([FromBody] User loginUser);
        ActionResult<User> Post([FromBody] User user);
        IActionResult Put(int id, [FromBody] User myUser);
    }
}