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
        private readonly IUserService _userService;
        private readonly IPasswordService _passwordService;

        public UserController(IUserService userService, IPasswordService passwordService)
        {
            _userService = userService;
            _passwordService = passwordService;
        }

        // GET: api/<UsersController>
        [HttpGet]
        async public Task<IEnumerable<string>> Get()
        {
            return new string[] { "" };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        async public Task<ActionResult<User>> Get(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        // POST api/<UsersController>
        [HttpPost]
        async public Task<ActionResult<User>> Post([FromBody] User user)
        {
            var newUser = await _userService.AddUser(user);
            if (newUser == null)
                return BadRequest("Password is not strong enough.");
            return CreatedAtAction(nameof(Get), new { id = newUser.UserId }, newUser);
        }

        [HttpPost("login")]
        async public Task<ActionResult<User>> Login([FromBody] User loginUser)
        {
            var user = await _userService.LoginUser(loginUser);
            if (user != null)
                return Ok(user);
            return Unauthorized();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        async public Task<IActionResult> Put(int id, [FromBody] User myUser)
        {
            bool p = await _userService.UpdateUser(id, myUser);
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
