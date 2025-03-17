using Microsoft.AspNetCore.Mvc;
using Portfolio.Services.Services.UserJWT.Create;
using Portfolio.Services.Services.UserJWT;

namespace Portfolio.API.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController(IUserService userService) : CustomBaseController
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserRequest request)
        {
            var result = await userService.RegisterAsync(request);
            return CreateActionResult(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserRequest request)
        {
            var result = await userService.LoginAsync(request);
            return CreateActionResult(result);
        }

        [HttpPost("refreshtoken")]
        public async Task<IActionResult> RefreshToken([FromBody] string refreshToken)
        {
            var result = await userService.RefreshTokenAsync(refreshToken);
            return CreateActionResult(result);
        }

        [HttpGet("getById/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await userService.GetByIdAsync(id);
            return CreateActionResult(result);
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await userService.DeleteAsync(id);
            return CreateActionResult(result);
        }
    }
}
