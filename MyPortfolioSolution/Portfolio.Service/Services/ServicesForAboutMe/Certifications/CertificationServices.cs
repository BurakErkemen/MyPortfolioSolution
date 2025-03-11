using Portfolio.Repositories.Models.RepositoriesForAboutMe.Certifications;
using Portfolio.Repositories.UnitOfWorkRepositories;

namespace Portfolio.Services.Services.ServicesForAboutMe.Certifications
{
    public class EducationServices(ICertificationRepository certificationRepository, IUnitOfWorkRepository unitOfWork) : IEdutionServices
    {
    }
}
