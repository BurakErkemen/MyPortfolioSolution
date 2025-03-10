using Portfolio.Repositories.GenericRepositories;

namespace Portfolio.Repositories.Models.Businesses
{
    public class BusinessRepository(PortfolioDbContext context) : GenericRepository<BusinessModel>(context), IBusinessRepository
    {
    }
}
