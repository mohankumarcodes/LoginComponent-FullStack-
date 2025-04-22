using LoginApp.Models;
using LoginApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LoginApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel user)
        {
            if (user == null || string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password))
            {
                return BadRequest("Name and Password are required.");
            }

            var result = await _authService.RegisterUser(user);
            if (result)
            {
                return Ok("User registered successfully.");
            }

            return BadRequest("Username is already taken.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var token = await _authService.Authenticate(model.Email, model.Password);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(new { Token = token ,message="User Loged....!"});

        }
    }
}
