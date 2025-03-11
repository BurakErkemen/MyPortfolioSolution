using Portfolio.Repositories.Models.RepositoriesForAboutMe.SocialMediaUrls;
using Portfolio.Repositories.UnitOfWorkRepositories;

namespace Portfolio.Services.Services.ServicesForAboutMe.SocialMediaUrls
{
    public class SocialMediaServices(ISocialMediaRepository socialMediaRepository, IUnitOfWorkRepository unitOfWork) : ISocialMediaServices
    {
    }
}
