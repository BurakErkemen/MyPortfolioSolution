using Portfolio.Repositories.GenericRepositories;

namespace Portfolio.Repositories.Models.RepositoriesForAboutMe.Educations
{
    public interface IEducationRepository : IGenericRepository<EducationModel>
    {
        Task<IEnumerable<EducationModel>> GetByAboutMeIdAsync(int aboutMeId);
    }
}
