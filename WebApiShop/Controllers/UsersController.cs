
using Microsoft.AspNetCore.Mvc;
using Entity; 
using Services;
using DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _UserSrvice;
        private readonly ILogger<UserController> _logger;
        public UserController(IUserServices IServiceUser, ILogger<UserController> logger) {
            _UserSrvice = IServiceUser;
            _logger = logger;
        }
        //ServiceUser services = new ServiceUser();

        //private static List<User> users = new List<User>();

       
        // GET api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            UserDTO? user =await _UserSrvice.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST api/Users/Login
        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> Login([FromBody] ExistingUserDTO existingUser)
        {
            UserDTO user = await _UserSrvice.Login(existingUser);
            if (user == null)
                return Unauthorized("Invalid email or password");

            _logger.LogInformation($"login attempted id:{user.UserId} email:{user.Email} first name:{user.FirstName} last name:{user.LastName}");
            return Ok(user);
        }

        
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Register([FromBody] UserDTO newUser)
        {
            UserDTO? user =await _UserSrvice.Register(newUser);
            if (user == null)
                return BadRequest("Password"); 

            return CreatedAtAction(nameof(GetUserById), new { id = newUser.UserId }, newUser);
        }

        // PUT api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserDTO updateUser)
        {
           bool success= await _UserSrvice.Update(id, updateUser);
            if(!success)
                return BadRequest("Password");
            return Ok();

        }

        // DELETE api/Users/5
        

        
    }
}