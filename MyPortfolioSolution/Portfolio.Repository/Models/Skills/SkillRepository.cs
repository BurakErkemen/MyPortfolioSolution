using Portfolio.Repositories.GenericRepositories;

namespace Portfolio.Repositories.Models.Skills
{
    public class SkillRepository(PortfolioDbContext context) : GenericRepository<SkillModel>(context), ISkillRepository
    {
    }
}
