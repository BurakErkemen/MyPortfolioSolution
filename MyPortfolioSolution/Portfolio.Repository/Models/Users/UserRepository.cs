using Microsoft.EntityFrameworkCore;
using Portfolio.Repositories.GenericRepositories;

namespace Portfolio.Repositories.Models.Users
{
    public class UserRepository(PortfolioDbContext context) : GenericRepository<UserModel>(context), IUserRepository
    { // Context olarak yazılacak
        public async Task<UserModel?> GetByEmailAsync(string email) // Kullanıcı girişinde veya şifre sıfırlamada lazım.
        {
            return await Context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<List<UserModel>> GetByNameAsync(string name)
        {
            return await Context.Users
                .AsNoTracking()
                .Where(x => x.Name == name)
                .ToListAsync();
        }

        public async Task<bool> IsEmailTakenAsync(string email) // Kayıt olurken e-posta kontrolü için.
        {
            return await Context.Users.AnyAsync(x => x.Email == email);
        }
    }
}
