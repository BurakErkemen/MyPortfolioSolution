using Portfolio.Repositories.GenericRepositories;

namespace Portfolio.Repositories.Models.Educations
{
    public class EducationRepository (PortfolioDbContext context) : GenericRepository<EducationModel>(context), IEducationRepository
    {
    }
}
