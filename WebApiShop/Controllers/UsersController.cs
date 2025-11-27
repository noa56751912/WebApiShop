
using Microsoft.AspNetCore.Mvc;
using Entity; 
using Services; 

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IServiceUser _IServiceUser;
        public UsersController(IServiceUser IServiceUser) {
            _IServiceUser = IServiceUser;
        }
        //ServiceUser services = new ServiceUser();

        //private static List<User> users = new List<User>();

       
        // GET api/Users/5
        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            User? user = _IServiceUser.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST api/Users/Login
        [HttpPost("Login")]
        public ActionResult<User> Login([FromBody] ExistingUser existingUser)
        {
            User? user = _IServiceUser.Login(existingUser);
            if (user == null)
                return Unauthorized(); 
            return Ok(user);
        }

        
        [HttpPost]
        public ActionResult<User> Register([FromBody] User newUser)
        {
            User? user = _IServiceUser.Register(newUser);
            if (user == null)
                return BadRequest("Password"); 

            return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
        }

        // PUT api/Users/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] User updateUser)
        {
           bool success= _IServiceUser.Update(id, updateUser);
            if(!success)
                return BadRequest("Password");
            return NoContent();

        }

        // DELETE api/Users/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _IServiceUser.Delete(id);
        }

        User? IServiceUser.GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        User? IServiceUser.Login(ExistingUser existingUser)
        {
            throw new NotImplementedException();
        }

        User? IServiceUser.Register(User newUser)
        {
            throw new NotImplementedException();
        }

        bool IServiceUser.Update(int id, User updateUser)
        {
            throw new NotImplementedException();
        }
    }
}