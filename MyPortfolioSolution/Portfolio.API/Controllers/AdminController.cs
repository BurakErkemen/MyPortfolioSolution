using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Services.Services.UserJWT;

namespace Portfolio.API.Controllers
{
    [Route("api/admin")]
    [ApiController]
    [Authorize(Roles = "Admin")] // Sadece Admin kullanıcıları erişebilir
    public class AdminController(IUserService userService) : CustomBaseController
    {
        [HttpGet("getAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await userService.GetAllAsync();
            return CreateActionResult(result);
        }

        [HttpGet("users/{id:int}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var result = await userService.GetByIdAsync(id);
            return CreateActionResult(result);
        }

        [HttpDelete("users/{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await userService.DeleteAsync(id);
            return CreateActionResult(result);
        }

    }
}