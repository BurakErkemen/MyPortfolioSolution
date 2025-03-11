using Portfolio.Repositories.GenericRepositories;

namespace Portfolio.Repositories.Models.RepositoriesForAboutMe.SocialMediaUrls
{
    public interface ISocialMediaRepository : IGenericRepository<SocialMediaModel>
    {
        Task<IEnumerable<SocialMediaModel>> GetByAboutMeIdAsync(int aboutMeId);
    }
}
