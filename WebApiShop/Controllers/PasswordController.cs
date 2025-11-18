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
        private readonly IServicePassword _IServicePassword;
        ServicePassword passwordService= new ServicePassword();
        public PasswordController(IServicePassword IServicePassword)
        {
            _IServicePassword = IServicePassword;
        }
        [HttpPost("PasswordStrength")]

        public ActionResult<User> PasswordStrength([FromBody] string password)
        {
            int strength = passwordService.PasswordStrength(password);
            return Ok(strength);
        }
    }
}
