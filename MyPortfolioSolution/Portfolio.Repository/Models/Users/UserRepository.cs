using Portfolio.Repositories.GenericRepositories;

namespace Portfolio.Repositories.Models.Users
{
    public class UserRepository(PortfolioDbContext context) : GenericRepository<UserModel>(context), IUserRepository
    {
        public Task<bool> DeactivateAccountAsync(int userId) // Hesabı pasif hale getir.
        {
            // Context olarak yazılacak
            throw new NotImplementedException();
        }

        public Task<bool> ReactivateAccountAsync(int userId) // Hesabı tekrar aktif hale getir.
        {
            throw new NotImplementedException();
        }

        public Task<UserModel?> GetByEmailAsync(string email) // Kullanıcı girişinde veya şifre sıfırlamada lazım.
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsEmailTakenAsync(string email) // Kayıt olurken e-posta kontrolü için.
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserRoleAsync(int userId, UserRoles newRole) // Admin, yazar gibi rolleri güncelle.
        {
            throw new NotImplementedException();
        }
    }
}
