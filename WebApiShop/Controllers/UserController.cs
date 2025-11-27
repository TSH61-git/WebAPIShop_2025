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
        public IEnumerable<string> Get()
        {
            return new string[] { "can't show users list:(" };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = _iUserService.GetUserById(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            var newUser = _iUserService.AddUser(user);
            if (newUser == null)
                return BadRequest("Password is not strong enough.");
            return CreatedAtAction(nameof(Get), new { id = newUser.UserId }, newUser);
        }

        [HttpPost("login")]
        public ActionResult<User> Login([FromBody] User loginUser)
        {
            var user = _iUserService.LoginUser(loginUser);
            if (user != null)
                return Ok(user);
            return NotFound();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User myUser)
        {
            bool p = _iUserService.UpdateUser(id, myUser);
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
