using Portfolio.Repositories.GenericRepositories;

namespace Portfolio.Repositories.Models.Certifications
{
    public class CertificationRepository(PortfolioDbContext context) : GenericRepository<CertificationModel>(context), ICertificationRepository
    {
    }
}
