using Entities;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents;
using Service;
using User = Entities.User;


namespace WebAPIShop.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase, IUserController
    {
        IUserService _iUserService;
        IPasswordService _iPasswordService;

        public UserController(IUserService userService, IPasswordService passwordService)
        {
            _iUserService = userService;
            _iPasswordService = passwordService;
        }

        // GET: api/<UsersController>
        [HttpGet]
        async public Task<IEnumerable<string>> Get()
        {
            return new string[] { "can't show users list:(" };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        async public Task<ActionResult<User>> Get(int id)
        {
            var user = await _iUserService.GetUserByIdasync(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        // POST api/<UsersController>
        [HttpPost]
        async public Task<ActionResult<User>> Post([FromBody] User user)
        {
            var newUser = _iUserService.AddUser(user);
            if (newUser == null)
                return BadRequest("Password is not strong enough.");
            return CreatedAtAction(nameof(Get), new { id = newUser.UserId }, newUser);
        }

        [HttpPost("login")]
        async public Task<ActionResult<User>> Login([FromBody] User loginUser)
        {
            var user = await _iUserService.LoginUserasync(loginUser);
            if (user != null)
                return Ok(user);
            return NotFound();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        async public Task<IActionResult> Put(int id, [FromBody] User myUser)
        {
            bool p = _iUserService.UpdateUserasync(id, myUser);
            if (!p)
                return BadRequest("Password is not strong enough");
            return NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
