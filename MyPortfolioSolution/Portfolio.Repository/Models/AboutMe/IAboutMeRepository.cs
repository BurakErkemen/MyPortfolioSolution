using Portfolio.Repositories.GenericRepositories;

namespace Portfolio.Repositories.Models.AboutMe
{
    public interface IAboutMeRepository : IGenericRepository<AboutMeModel>
    {
        Task<AboutMeModel?> GetByUserIdAsync(int userId);
    }
}
