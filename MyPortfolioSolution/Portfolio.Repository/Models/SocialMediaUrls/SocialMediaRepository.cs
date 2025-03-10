
using Portfolio.Repositories.GenericRepositories;

namespace Portfolio.Repositories.Models.SocialMediaUrls
{
    public class SocialMediaRepository(PortfolioDbContext context) : GenericRepository<SocialMediaModel>(context), ISocialMediaRepository
    {
    }
}
