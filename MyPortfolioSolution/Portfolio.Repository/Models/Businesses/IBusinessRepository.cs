using Portfolio.Repositories.GenericRepositories;

namespace Portfolio.Repositories.Models.Businesses
{
    public interface IBusinessRepository : IGenericRepository<BusinessModel>
    {
        Task<IEnumerable<BusinessModel>> GetByAboutMeIdAsync(int aboutMeId);
    }
}