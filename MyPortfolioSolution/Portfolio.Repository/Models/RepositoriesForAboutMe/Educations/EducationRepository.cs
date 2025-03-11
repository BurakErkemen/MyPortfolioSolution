using Microsoft.EntityFrameworkCore;
using Portfolio.Repositories.GenericRepositories;

namespace Portfolio.Repositories.Models.RepositoriesForAboutMe.Educations
{
    public class EducationRepository(PortfolioDbContext context) : GenericRepository<EducationModel>(context), IEducationRepository
    {
        public async Task<IEnumerable<EducationModel>> GetByAboutMeIdAsync(int aboutMeId)
        {
            return await Context.Educations.Where(e => e.AboutMeId == aboutMeId).ToListAsync();
        }
    }
}
