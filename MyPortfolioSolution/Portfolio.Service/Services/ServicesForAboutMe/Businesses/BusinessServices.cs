using Portfolio.Repositories.Models.RepositoriesForAboutMe.Businesses;
using Portfolio.Repositories.UnitOfWorkRepositories;

namespace Portfolio.Services.Services.ServicesForAboutMe.Businesses
{
    public class BusinessServices(IBusinessRepository businessRepository,IUnitOfWorkRepository unitOfWork) : IBusinessServices
    {
    }
}
