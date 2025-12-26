using Entity;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Services;
using DTOs;
namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController:ControllerBase
    {
        private readonly IPasswordServices _IServicePassword;
        PasswordServices passwordService= new PasswordServices();
        public PasswordController(IPasswordServices IServicePassword)
        {
            _IServicePassword = IServicePassword;
        }
        [HttpPost("PasswordStrength")]

        public ActionResult<UserDTO> PasswordStrength([FromBody] string password)
        {
            int strength = passwordService.PasswordStrength(password);
            return Ok(strength);
        }
    }
}
