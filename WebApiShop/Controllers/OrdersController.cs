
using Microsoft.AspNetCore.Mvc;
using Entity; 
using Services; 

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IServiceUser _IServiceUser;
        public ProductsController(IServiceUser IServiceUser) {
            _IServiceUser = IServiceUser;
        }
        //ServiceUser services = new ServiceUser();

        //private static List<User> users = new List<User>();

       
        // GET api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            User? user =await _IServiceUser.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST api/Users/Login
        [HttpPost("Login")]
        public async Task<ActionResult<User>> Login([FromBody] ExistingUser existingUser)
        {
            User? user =await _IServiceUser.Login(existingUser);
            if (user == null)
                return NotFound(); 
            return Ok(user);
        }

        
        [HttpPost]
        public async Task<ActionResult<User>> Register([FromBody] User newUser)
        {
            User? user =await _IServiceUser.Register(newUser);
            if (user == null)
                return BadRequest("Password"); 

            return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
        }

        // PUT api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] User updateUser)
        {
           bool success= await _IServiceUser.Update(id, updateUser);
            if(!success)
                return BadRequest("Password");
            return Ok();

        }

        // DELETE api/Users/5
        

        
    }
}