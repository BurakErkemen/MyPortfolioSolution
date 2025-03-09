using Portfolio.Repositories.Models.Users;
using Portfolio.Services.Services.Users.Create;
using Portfolio.Services.Services.Users.Update;

namespace Portfolio.Services.Services.Users
{
    public interface IUserService
    {
        Task<ServiceResult> DeactivateAccountAsync(string email);// Hesabı pasif hale getir.
        Task<ServiceResult> ReactivateAccountAsync(string email);// Hesabı tekrar aktif hale getir.
        Task<ServiceResult> UpdateUserRoleAsync(int Id, UserRoles UserRole); // Admin, yazar gibi rolleri güncelle.

        Task<ServiceResult<List<UserResponse>>> GetAllAsync();
        Task<ServiceResult<UserResponse?>> GetByIdAsync(int id);
        Task<ServiceResult<List<UserResponse>>> GetByNameAsync(string Name);
        Task<ServiceResult<CreateUserResponse?>> CreateAsync(CreateUserRequest request);
        Task<ServiceResult> UpdateAsync(UpdateUserRequest request);
        Task<ServiceResult> DeleteAsync(int id);
    }
}