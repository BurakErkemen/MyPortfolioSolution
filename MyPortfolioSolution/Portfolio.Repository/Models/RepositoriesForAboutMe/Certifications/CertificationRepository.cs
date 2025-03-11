using Microsoft.EntityFrameworkCore;
using Portfolio.Repositories.GenericRepositories;

namespace Portfolio.Repositories.Models.RepositoriesForAboutMe.Certifications
{
    public class CertificationRepository(PortfolioDbContext context) : GenericRepository<CertificationModel>(context), ICertificationRepository
    {
        public async Task<IEnumerable<CertificationModel>> GetByAboutMeIdAsync(int aboutMeId)
        {
            return await Context.Certifications.Where(c => c.AboutMeId == aboutMeId).ToListAsync();
        }
    }
}
