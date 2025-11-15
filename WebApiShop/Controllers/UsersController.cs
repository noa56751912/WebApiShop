
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
using Entity;
using Repository;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace WebApiShop.Controllers
{
=======
using System.Text.Json;


//using System.IO;
//using System;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiShop.Controllers
{
    
>>>>>>> ed8913a3128f6670c339bb1fe93f875e19e64361
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        string path = "file.txt";
<<<<<<< HEAD
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
=======

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


>>>>>>> ed8913a3128f6670c339bb1fe93f875e19e64361
        }
        [HttpPost("Login")]
        public ActionResult<User> Login([FromBody] ExistingUser existingUser)
        {
<<<<<<< HEAD
            User? user = service.Login(existingUser);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
=======
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
>>>>>>> ed8913a3128f6670c339bb1fe93f875e19e64361

        }
        // POST api/<Users>

        // POST api/<UsersControllers>

        [HttpPost]
        
<<<<<<< HEAD
        public ActionResult<User> Register([FromBody] User newUser) {

            User? user = service.Register(newUser);
            if (user == null) 
                return NotFound();
            return CreatedAtAction(nameof(GetUserById), new { newUser.Id }, newUser);
=======
        public ActionResult<User> Post([FromBody] User newUser) {
            

            //int loggedInId = sessionStorage.getItem('currentUserId');
            int numberOfUsers = System.IO.File.ReadLines(path).Count();
            newUser.Id= numberOfUsers+1;
            string userJson = JsonSerializer.Serialize(newUser);
            System.IO.File.AppendAllText(path, userJson + Environment.NewLine);
            return CreatedAtAction(nameof(Get), new { newUser.Id }, newUser);
>>>>>>> ed8913a3128f6670c339bb1fe93f875e19e64361
        }

        // PUT api/<UsersControllers>/5
        [HttpPut("{id}")]
<<<<<<< HEAD
        public void Update(int id, [FromBody] User updateUser)
        {
            service.Update(id, updateUser);
=======
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
>>>>>>> ed8913a3128f6670c339bb1fe93f875e19e64361
        }

        // DELETE api/<UsersControllers>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
<<<<<<< HEAD
            service.Delete(id);
=======
>>>>>>> ed8913a3128f6670c339bb1fe93f875e19e64361
        }
    }
}
