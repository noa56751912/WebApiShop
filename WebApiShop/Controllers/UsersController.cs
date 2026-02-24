using DTOs;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserServices userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        // GET api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            UserDTO user = await _userService.GetUserById(id);
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
            UserDTO user = await _userService.Login(existingUser);
            if (user == null)
                return Unauthorized("Invalid email or password");

            _logger.LogInformation($"login attempted id:{user.UserId} email:{user.Email} first name:{user.FirstName} last name:{user.LastName}");
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> Register([FromBody] UserDTO newUser)
        {
            UserDTO user = await _userService.Register(newUser);
            if (user == null)
                return BadRequest("Password too weak");

            return CreatedAtAction(nameof(GetUserById), new { id = newUser.UserId }, newUser);
        }

        // PUT api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserDTO updateUser)
        {
            bool success = await _userService.Update(id, updateUser);
            if (!success)
                return BadRequest("Password too weak");
            return NoContent();
        }
    }
}