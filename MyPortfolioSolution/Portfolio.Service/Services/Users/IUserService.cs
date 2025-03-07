using Portfolio.Services.Services.Users.Create;
using Portfolio.Services.Services.Users.Update;

namespace Portfolio.Services.Services.Users
{
    public interface IUserService
    {
        Task<ServiceResult> DeactivateAccountAsync(UpdateUserRequest request);// Hesabı pasif hale getir.
        Task<ServiceResult> ReactivateAccountAsync(UpdateUserRequest request);// Hesabı tekrar aktif hale getir.
        Task<ServiceResult> UpdateUserRoleAsync(UpdateUserRequest request); // Admin, yazar gibi rolleri güncelle.

        Task<ServiceResult<UserResponse?>> GetAllAsync();
        Task<ServiceResult<UserResponse?>> GetByIdAsync(int id);
        Task<ServiceResult<CreateUserResponse>> CreateAsync(CreateUserRequest request);
        Task<ServiceResult> UpdateAsync(UpdateUserRequest request);
        Task<ServiceResult> DeleteAsync(int id);
    }
}