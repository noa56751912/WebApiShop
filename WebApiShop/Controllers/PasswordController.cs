using Entity;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Services;
namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController:ControllerBase
    {
         ServicePassword passwordService= new ServicePassword();
        [HttpPost("PasswordStrength")]

        public ActionResult<User> PasswordStrength([FromBody] string password)
        {
            int strength = passwordService.PasswordStrength(password);
            return Ok(strength);
        }
    }
}
