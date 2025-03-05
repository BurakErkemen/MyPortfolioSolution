using Portfolio.Services.Services.Users.Update;

namespace Portfolio.Services.Services.Users
{
    public interface IUserService
    {
        Task<ServiceResult> DeactivateAccountAsync(UpdateUserRequest request);// Hesabı pasif hale getir.
        Task<ServiceResult> ReactivateAccountAsync(UpdateUserRequest request);// Hesabı tekrar aktif hale getir.
        Task<ServiceResult> UpdateUserRoleAsync(UpdateUserRequest request); // Admin, yazar gibi rolleri güncelle.
    }
}
