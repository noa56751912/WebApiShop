
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Entity;
using Repository;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        string path = "file.txt";
        ServiceUser service = new ServiceUser();

        // GET: api/<UsersControllers>
        // [HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return ;
        //}

        // GET api/<UsersControllers>/5
        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            User? user= service.GetUserById(id);
            if (user == null) { 
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPost("Login")]
        public ActionResult<User> Login([FromBody] ExistingUser existingUser)
        {
            User? user = service.Login(existingUser);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);

        }
        // POST api/<Users>

        // POST api/<UsersControllers>

        [HttpPost]
        
        public ActionResult<User> Register([FromBody] User newUser) {

            User? user = service.Register(newUser);
            if (user == null) 
                return NotFound();
            return CreatedAtAction(nameof(GetUserById), new { newUser.Id }, newUser);
        }

        // PUT api/<UsersControllers>/5
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] User updateUser)
        {
            service.Update(id, updateUser);
        }

        // DELETE api/<UsersControllers>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.Delete(id);
        }
    }
}
