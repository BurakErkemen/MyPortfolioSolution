using Portfolio.Repositories.GenericRepositories;

namespace Portfolio.Repositories.Models.Users
{
    public interface IUserRepository : IGenericRepository<UserModel>
    {
        Task<UserModel?> GetByEmailAsync(string email); //Kullanıcı girişinde veya şifre sıfırlamada lazım.
        Task<bool> IsEmailTakenAsync(string email); // Kayıt olurken e-posta kontrolü için.
        Task UpdateUserRoleAsync(int userId, UserRoles newRole); // Admin, yazar gibi rolleri güncelle.
        Task<bool> DeactivateAccountAsync(int userId);// Hesabı pasif hale getir.
        Task<bool> ReactivateAccountAsync(int userId);// Hesabı tekrar aktif hale getir.
    }
}
