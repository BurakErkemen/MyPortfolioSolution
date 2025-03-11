using Portfolio.Repositories.GenericRepositories;

namespace Portfolio.Repositories.Models.RepositoriesForAboutMe.Skills
{
    public interface ISkillRepository : IGenericRepository<SkillModel>
    {
        Task<IEnumerable<SkillModel>> GetByAboutMeIdAsync(int aboutMeId);
    }
}
