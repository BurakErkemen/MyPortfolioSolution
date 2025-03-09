using Portfolio.Services.Services.ContactForms.Create;

namespace Portfolio.Services.Services.ContactForms
{
    public interface IContactFormService 
    {
        Task<ServiceResult<List<ContactFormResponse>>> GetAllAsync();
        Task<ServiceResult<List<ContactFormResponse>>> GetByNameAsync(string name);
        Task<ServiceResult<List<ContactFormResponse>>> GetByEmailAsync(string email);
        Task<ServiceResult<List<ContactFormResponse>>> GetByCompanyNameAsync(string companyName);
        Task<ServiceResult> CreateAsync(CreateContactFormRequest request);
        Task<ServiceResult> DeleteAsync(int id);
    }
}
