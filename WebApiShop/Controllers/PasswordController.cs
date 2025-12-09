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
        private readonly IServicePassword _servicePassword;
        public PasswordController(IServicePassword servicePassword)
        {
            _servicePassword = servicePassword;
        }
        [HttpPost("PasswordStrength")]

        public ActionResult<int> PasswordStrength([FromBody] string password)
        {
            int strength = _servicePassword.PasswordStrength(password);
            return Ok(strength);
        }
    }
}
