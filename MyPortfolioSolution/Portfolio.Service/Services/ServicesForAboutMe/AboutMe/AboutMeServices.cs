using Portfolio.Repositories.Models.RepositoriesForAboutMe.AboutMe;
using Portfolio.Repositories.UnitOfWorkRepositories;

namespace Portfolio.Services.Services.ServicesForAboutMe.AboutMe
{
    public class AboutMeServices(IAboutMeRepository aboutMeRepository, IUnitOfWorkRepository unitOfWork) : IAboutMeServices
    {
    }
}
