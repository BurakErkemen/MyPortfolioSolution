using Portfolio.Repositories.GenericRepositories;

namespace Portfolio.Repositories.Models.AboutMe
{
    public class AboutMeRepository(PortfolioDbContext context) : GenericRepository<AboutMeModel>(context), IAboutMeRepository
    {
    }
}
