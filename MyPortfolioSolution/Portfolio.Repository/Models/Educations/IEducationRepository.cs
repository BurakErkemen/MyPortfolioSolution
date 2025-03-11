using Portfolio.Repositories.GenericRepositories;

namespace Portfolio.Repositories.Models.Educations
{
    public interface IEducationRepository : IGenericRepository<EducationModel>
    {
        Task<IEnumerable<EducationModel>> GetByAboutMeIdAsync(int aboutMeId);

    }
}
