using Portfolio.Repositories.Models.Users;
using Portfolio.Repositories.UnitOfWorkRepositories;
using Portfolio.Services.Services.Users.Update;
using System.Net;

namespace Portfolio.Services.Services.Users
{
    public class UserService(IUserRepository userRepository, IUnitOfWorkRepository unitOfWork) : IUserService
    {
        public async Task<ServiceResult> DeactivateAccountAsync(UpdateUserRequest request)
        {
            var user = await userRepository.GetByIdAsync(request.Id);
            if (user == null)
            {
                return ServiceResult.Fail("User not found", HttpStatusCode.NotFound);
            }
            // Kullanıcının hesabını pasif hale getir
            user.IsActivate = request.AccountStatus;
            userRepository.UpdateAsync(user);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public Task<ServiceResult> ReactivateAccountAsync(UpdateUserRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> UpdateUserRoleAsync(UpdateUserRequest request)
        {
            throw new NotImplementedException();
        }

    }
}
