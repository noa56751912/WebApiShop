
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;


//using System.IO;
//using System;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiShop.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        string path = "file.txt";

        // GET: api/<UsersControllers>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UsersControllers>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            using (StreamReader reader = System.IO.File.OpenText(path))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Id == id)
                        return Ok(user);
                }
            }
            return NotFound();


        }
        [HttpPost("Login")]
        public ActionResult<User> Login([FromBody] ExistingUser existingUser)
        {
            using (StreamReader reader = System.IO.File.OpenText("text.txt"))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Email == existingUser.Email && user.Password == existingUser.Password)
                        return Ok(user);
                }
            }
            return NotFound();

        }
        // POST api/<Users>

        // POST api/<UsersControllers>

        [HttpPost]
        
        public ActionResult<User> Post([FromBody] User newUser) {
            

            //int loggedInId = sessionStorage.getItem('currentUserId');
            int numberOfUsers = System.IO.File.ReadLines(path).Count();
            newUser.Id= numberOfUsers+1;
            string userJson = JsonSerializer.Serialize(newUser);
            System.IO.File.AppendAllText(path, userJson + Environment.NewLine);
            return CreatedAtAction(nameof(Get), new { newUser.Id }, newUser);
        }

        // PUT api/<UsersControllers>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User updateUser)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText("text.txt"))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user= JsonSerializer.Deserialize<User>(currentUserInFile);
                    if(user.Id==id)
                        textToReplace = currentUserInFile;
                }
            }

            if(textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText("text.txt");
                text = text.Replace(textToReplace, JsonSerializer.Serialize(updateUser));
                System.IO.File.WriteAllText("text.txt", text);
            }
        }

        // DELETE api/<UsersControllers>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
