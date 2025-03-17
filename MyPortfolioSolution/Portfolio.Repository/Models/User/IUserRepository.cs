using Portfolio.Repositories.GenericRepositories;

namespace Portfolio.Repositories.Models.User
{
    public interface IUserRepository : IGenericRepository<UserModel>
    {
        Task<UserModel?> GetByUsernameAsync(string username);
    }
}
