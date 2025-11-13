using Entity;
using Service;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIShop.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly Service.Service _service = new Service.Service();

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "can't show users list:(" };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<Users> Get(int id)
        {
            var user = _service.getUserByID(id);
            if (user == null)
                return NoContent(); 
            return Ok(user);
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult<Users> Post([FromBody] Users user)
        {
            var newUser = _service.addUser(user);
            return CreatedAtAction(nameof(Get), new { id = newUser.UserId }, newUser);
        }

        [HttpPost("login")]
        public ActionResult<Users> Login([FromBody] LoginUsers loginUser)
        {
            var user = _service.loginUser(loginUser);
            if (user != null)
                return Ok(user);
            return NotFound();
        }

        [HttpPost("checkPassword")]
        public ActionResult<int> checkPassword([FromBody]string password)
        {
            var score = _service.checkPasswordStrong(password);
            Response.Headers.Add("X-Password-Score", score.ToString());
            return NoContent();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Users myUser)
        {
            _service.updateUser(id, myUser);
            return NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
