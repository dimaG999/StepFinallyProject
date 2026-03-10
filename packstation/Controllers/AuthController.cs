using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using packstation.Dtos;
using packstation.Services;

namespace packstation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;

        public AuthController(IUserService userService, IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpPost("ADMIN LogIn")]
        public async Task<IActionResult> Login([FromBody] LogInDto dto)
        {
            var user = await _userService.GetUserByEmailForLoginAsync(dto.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return Unauthorized();

            var token = _jwtService.GenerateToken(user);

            return Ok(new { token });
        }
    }
}
