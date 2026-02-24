using DTOs;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Services;

namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        private readonly IPasswordServices _passwordService;

        public PasswordController(IPasswordServices passwordService)
        {
            _passwordService = passwordService;
        }

        [HttpPost("PasswordStrength")]
        public ActionResult<int> PasswordStrength([FromBody] string password)
        {
            int strength = _passwordService.PasswordStrength(password);
            return Ok(strength);
        }
    }
}
