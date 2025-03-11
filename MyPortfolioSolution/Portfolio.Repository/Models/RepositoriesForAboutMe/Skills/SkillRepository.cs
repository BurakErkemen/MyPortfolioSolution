using Microsoft.EntityFrameworkCore;
using Portfolio.Repositories.GenericRepositories;

namespace Portfolio.Repositories.Models.RepositoriesForAboutMe.Skills
{
    public class SkillRepository(PortfolioDbContext context) : GenericRepository<SkillModel>(context), ISkillRepository
    {
        public async Task<IEnumerable<SkillModel>> GetByAboutMeIdAsync(int aboutMeId)
        {
            return await Context.Skills.Where(s => s.AboutMeId == aboutMeId).ToListAsync();
        }
    }
}
