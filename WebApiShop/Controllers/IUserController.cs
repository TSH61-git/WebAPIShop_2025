using Entities;
using Repository.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIShop.Controllers
{
    public interface IUserController
    {
        void Delete(int id);
        Task<IEnumerable<string>> Get();
        Task<ActionResult<User>> Get(int id);
        Task<ActionResult<User>> Login([FromBody] User loginUser);
        Task<ActionResult<User>> Post([FromBody] User user);
        Task<IActionResult> Put(int id, [FromBody] User myUser);
    }
}