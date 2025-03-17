using Microsoft.EntityFrameworkCore;
using Portfolio.Repositories.GenericRepositories;

namespace Portfolio.Repositories.Models.User
{
    public class UserRepository(PortfolioDbContext context) : GenericRepository<UserModel>(context), IUserRepository
    {
        public async Task<UserModel?> GetByUsernameAsync(string username)
        {
            return await Context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
