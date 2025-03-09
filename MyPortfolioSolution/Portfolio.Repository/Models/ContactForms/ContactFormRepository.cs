using Microsoft.EntityFrameworkCore;
using Portfolio.Repositories.GenericRepositories;

namespace Portfolio.Repositories.Models.ContactForms
{
    public class ContactFormRepository(PortfolioDbContext context) : GenericRepository<ContactFormModel>(context), IContactFormRepository
    {
        public async Task<List<ContactFormModel>> GetByCompanyNameAsync(string companyName)
        {
            return await Context.ContactForms
                .AsNoTracking()
                .Where(x => x.Company == companyName)
                .ToListAsync();
        }

        public async Task<List<ContactFormModel>> GetByEmailAsync(string email)
        {
            return await Context.ContactForms
                .AsNoTracking()
                .Where(x => x.Email == email)
                .ToListAsync();
        }

        public async Task<List<ContactFormModel>> GetByNameAsync(string name)
        {
            return await Context.ContactForms
                .AsNoTracking()
                .Where(x => x.Name == name)
                .ToListAsync();
        }
    }
}