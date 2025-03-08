using Portfolio.Repositories.GenericRepositories;

namespace Portfolio.Repositories.Models.Users
{
    public interface IUserRepository : IGenericRepository<UserModel>
    {
        Task<UserModel?> GetByEmailAsync(string email); //Kullanıcı girişinde veya şifre sıfırlamada lazım.
        Task<bool> IsEmailTakenAsync(string email); // Kayıt olurken e-posta kontrolü için.
        Task<List<UserModel>> GetByNameAsync(string name);
    }
}
