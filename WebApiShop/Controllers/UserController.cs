using DTOs;
using Entities;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<UserReadDTO>> Get(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<UserReadDTO>> Post([FromBody] UserRegisterDTO userRegisterDto)
        {
            var newUser = await _userService.AddUser(userRegisterDto);
            if (newUser == null)
                return BadRequest("Registration failed or password is not strong enough.");

            return CreatedAtAction(nameof(Get), new { id = newUser.UserId }, newUser);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserReadDTO>> Login([FromBody] UserLoginDTO loginDto)
        {
            var user = await _userService.LoginUser(loginDto);
            if (user != null)
                return Ok(user);
            return Unauthorized();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserRegisterDTO userUpdateDto)
        {
            bool isUpdated = await _userService.UpdateUser(id, userUpdateDto);
            if (!isUpdated)
                return BadRequest("Update failed. Please check password strength.");
            return NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
