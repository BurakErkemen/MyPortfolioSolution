using Microsoft.EntityFrameworkCore;
using Portfolio.Repositories.GenericRepositories;

namespace Portfolio.Repositories.Models.Businesses
{
    public class BusinessRepository(PortfolioDbContext context) : GenericRepository<BusinessModel>(context), IBusinessRepository
    {
        public async Task<IEnumerable<BusinessModel>> GetByAboutMeIdAsync(int aboutMeId)
        {
            return await Context.Businesses.Where(b => b.AboutMeId == aboutMeId).ToListAsync();
        }
    }
}
