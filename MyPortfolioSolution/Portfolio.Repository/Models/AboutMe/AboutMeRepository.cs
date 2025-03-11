using Microsoft.EntityFrameworkCore;
using Portfolio.Repositories.GenericRepositories;

namespace Portfolio.Repositories.Models.AboutMe
{
    public class AboutMeRepository(PortfolioDbContext context) : GenericRepository<AboutMeModel>(context), IAboutMeRepository
    {
        public async Task<AboutMeModel?> GetByUserIdAsync(int userId)
        {
            return await Context.AboutMe
                .Include(a => a.Business)
                .Include(a => a.Certifications)
                .Include(a => a.Skills)
                .Include(a => a.SocialMediaLinks)
                .FirstOrDefaultAsync(a => a.UserId == userId);
        }
    }
}
