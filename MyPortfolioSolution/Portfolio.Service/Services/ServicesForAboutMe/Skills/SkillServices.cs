using Portfolio.Repositories.Models.RepositoriesForAboutMe.Skills;
using Portfolio.Repositories.UnitOfWorkRepositories;

namespace Portfolio.Services.Services.ServicesForAboutMe.Skills
{
    public class SkillServices(ISkillRepository skillRepository , IUnitOfWorkRepository unitOfWork) : ISkillServices
    {
    }
}
