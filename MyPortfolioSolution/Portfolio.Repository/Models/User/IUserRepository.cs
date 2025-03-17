using Portfolio.Repositories.GenericRepositories;

namespace Portfolio.Repositories.Models.User
{
    public interface IUserRepository : IGenericRepository<UserModel>
    {
        Task<UserModel?> GetByUsernameAsync(string username);
        Task<UserModel?> GetByEmailAsync(string email);
        Task<UserModel?> GetByRefreshTokenAsync(string refreshToken); // RefreshToken eklenmeli

    }
}
