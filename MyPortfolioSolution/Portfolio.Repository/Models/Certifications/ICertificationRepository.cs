using Portfolio.Repositories.GenericRepositories;

namespace Portfolio.Repositories.Models.Certifications
{
    public interface ICertificationRepository : IGenericRepository<CertificationModel>
    {
        Task<IEnumerable<CertificationModel>> GetByAboutMeIdAsync(int aboutMeId);
    }
}
