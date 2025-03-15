using Portfolio.Repositories.GenericRepositories;

namespace Portfolio.Repositories.Models.ContactForms
{
    public interface IContactFormRepository : IGenericRepository<ContactFormModel>
    {
        Task<List<ContactFormModel>> GetByEmailAsync(string email);
        Task<List<ContactFormModel>> GetByNameAsync(string name);
        Task<List<ContactFormModel>> GetByCompanyNameAsync(string companyName);
    }
}