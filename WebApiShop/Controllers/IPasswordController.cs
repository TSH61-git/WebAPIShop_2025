using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApiShop.Controllers
{
    public interface IPasswordController
    {
        IActionResult checkPassword([FromBody] Passwords password);
        void Delete(int id);
        IEnumerable<string> Get();
        string Get(int id);
        void Put(int id, [FromBody] string value);
    }
}