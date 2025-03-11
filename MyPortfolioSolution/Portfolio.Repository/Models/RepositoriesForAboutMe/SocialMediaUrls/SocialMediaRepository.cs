
using Microsoft.EntityFrameworkCore;
using Portfolio.Repositories.GenericRepositories;

namespace Portfolio.Repositories.Models.RepositoriesForAboutMe.SocialMediaUrls
{
    public class SocialMediaRepository(PortfolioDbContext context) : GenericRepository<SocialMediaModel>(context), ISocialMediaRepository
    {
        public async Task<IEnumerable<SocialMediaModel>> GetByAboutMeIdAsync(int aboutMeId)
        {
            return await Context.SocialMediaLinks.Where(s => s.AboutMeId == aboutMeId).ToListAsync();
        }
    }
}
