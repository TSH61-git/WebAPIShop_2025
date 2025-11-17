using Entities;
using Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase, IPasswordController
    {
        IPasswordService _iPasswordService;

        public PasswordController(IUserService userService, IPasswordService passwordService)
        {
            _iPasswordService = passwordService;
        }

        // GET: api/<PasswordController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PasswordController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PasswordController>
        [HttpPost]
        public IActionResult checkPassword([FromBody] Passwords password)
        {
            Passwords resPassword = _iPasswordService.checkPasswordStrong(password);
            if (resPassword == null)
                return NoContent();
            return Ok(resPassword);
        }

        // PUT api/<PasswordController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PasswordController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
