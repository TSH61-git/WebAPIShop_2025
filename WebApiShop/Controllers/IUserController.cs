using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIShop.Controllers
{
    public interface IUserController
    {
        void Delete(int id);
        IEnumerable<string> Get();
        ActionResult<Users> Get(int id);
        ActionResult<Users> Login([FromBody] Users loginUser);
        ActionResult<Users> Post([FromBody] Users user);
        IActionResult Put(int id, [FromBody] Users myUser);
    }
}