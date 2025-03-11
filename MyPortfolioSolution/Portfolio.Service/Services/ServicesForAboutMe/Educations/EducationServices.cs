using Portfolio.Repositories.Models.RepositoriesForAboutMe.Educations;
using Portfolio.Repositories.UnitOfWorkRepositories;

namespace Portfolio.Services.Services.ServicesForAboutMe.Educations
{
    public class EducationServices(IEducationRepository educationRepository, IUnitOfWorkRepository unitOfWork) : IEducationServices
    {
    }
}
