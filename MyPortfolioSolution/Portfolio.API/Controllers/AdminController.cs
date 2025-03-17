using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Services.Services.User;

namespace Portfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController(IAuthService authService) : CustomBaseController
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var token = await authService.AuthenticateAsync(request.Email, request.Password);

            if (token == null) return Unauthorized("Geçersiz giriş!");

            return Ok(new { Token = token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            await authService.(request.Email, request.Password);
            return Ok("Kullanıcı başarıyla oluşturuldu!");
        }
    }
}