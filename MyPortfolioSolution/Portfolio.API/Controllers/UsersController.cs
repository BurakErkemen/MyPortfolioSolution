using Microsoft.AspNetCore.Mvc;
using Portfolio.Repositories.Models.Users;
using Portfolio.Services.Services.Users;
using Portfolio.Services.Services.Users.Create;
using Portfolio.Services.Services.Users.Update;

namespace Portfolio.API.Controllers
{
    [Route("api/User")]
    public class UsersController (IUserService userService) : CustomBaseController
    {
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var userResult = await userService.GetAllAsync();

            return CreateActionResult(userResult);
        }


        [HttpGet("getbyId/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var userResult = await userService.GetByIdAsync(id);

            return CreateActionResult(userResult);
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateUserRequest request)
        {
            var userResult = await userService.CreateAsync(request);

            return CreateActionResult(userResult);
        }


        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateUserRequest request)
        {
            var userResult = await userService.UpdateAsync(request);

            return CreateActionResult(userResult);
        }


        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userResult = await userService.DeleteAsync(id);

            return CreateActionResult(userResult);
        }


        [HttpPatch("deactivate/{email:string}")]
        public async Task<IActionResult> DeactivateAccountAsync(string email)
        {
            var userResult = await userService.DeactivateAccountAsync(email);

            return CreateActionResult(userResult);
        }


        [HttpPatch("reactivate/{email:string}")]
        public async Task<IActionResult> ReactivateAccountAsync(string email)
        {
            var userResult = await userService.ReactivateAccountAsync(email);

            return CreateActionResult(userResult);
        }


        [HttpGet("getByName/{name:string}")]
        public async Task<IActionResult> GetByNameAsync(string name)
        {
            var userResult = await userService.GetByNameAsync(name);

            return CreateActionResult(userResult);
        }


        [HttpPatch("updateUserRole/{Id:int}")]
        public async Task<IActionResult> UpdateUserRoleAsync(int id, UserRoles userRoles)
        {
            var userResult = await userService.UpdateUserRoleAsync(id,userRoles);

            return CreateActionResult(userResult);
        }
    }
}