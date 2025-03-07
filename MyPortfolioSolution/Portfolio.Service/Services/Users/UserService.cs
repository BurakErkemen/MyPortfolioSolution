using Portfolio.Repositories.Models.Users;
using Portfolio.Repositories.UnitOfWorkRepositories;
using Portfolio.Services.Services.Users.Create;
using Portfolio.Services.Services.Users.Update;
using System.Net;

namespace Portfolio.Services.Services.Users
{
    public class UserService(IUserRepository userRepository, IUnitOfWorkRepository unitOfWork) : IUserService
    {
        public async Task<ServiceResult> DeactivateAccountAsync(UpdateUserRequest request) // Hesabı pasif hale getir.
        {
            var user = await userRepository.GetByEmailAsync(request.Email);
            if (user == null) return ServiceResult.Fail("User not found", HttpStatusCode.NotFound);
            
            // Kullanıcının hesabını pasif hale getir
            user.IsActivate = request.AccountStatus;
            userRepository.UpdateAsync(user);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }
        public async Task<ServiceResult> ReactivateAccountAsync(UpdateUserRequest request) // Hesabı tekrar aktif hale getir.
        {
            var user = await userRepository.GetByEmailAsync(request.Email);
            if (user == null) return ServiceResult.Fail("User not found!", HttpStatusCode.NotFound);

            // Kullanıcının hesabını aktif hale getir 
            user.IsActivate = request.AccountStatus;
            userRepository.UpdateAsync(user);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }
        public Task<ServiceResult> UpdateUserRoleAsync(UpdateUserRequest request) // Admin, yazar gibi rolleri güncelle.
        {
            var user = userRepository.GetByIdAsync(request.Id);
            if (user == null) return ServiceResult.Fail("User not found!", HttpStatusCode.NotFound);

            // Rol güncelleme
            
        }
        public Task<ServiceResult<UserResponse?>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public Task<ServiceResult<UserResponse?>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<ServiceResult<CreateUserResponse>> CreateAsync(CreateUserRequest request)
        {
            throw new NotImplementedException();
        }
        public Task<ServiceResult> UpdateAsync(UpdateUserRequest request)
        {
            throw new NotImplementedException();
        }
        public Task<ServiceResult> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
