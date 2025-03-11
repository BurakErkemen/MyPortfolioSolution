using Portfolio.Repositories.GenericRepositories;

namespace Portfolio.Repositories.Models.RepositoriesForAboutMe.Certifications
{
    public interface ICertificationRepository : IGenericRepository<CertificationModel>
    {
        Task<IEnumerable<CertificationModel>> GetByAboutMeIdAsync(int aboutMeId);
    }
}
