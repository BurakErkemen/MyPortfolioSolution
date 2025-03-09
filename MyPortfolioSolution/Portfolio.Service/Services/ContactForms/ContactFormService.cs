using System.Net;
using Microsoft.EntityFrameworkCore;
using Portfolio.Repositories.Models.ContactForms;
using Portfolio.Repositories.UnitOfWorkRepositories;
using Portfolio.Services.Services.ContactForms.Create;

namespace Portfolio.Services.Services.ContactForms
{
    public class ContactFormService(IContactFormRepository contactFormRepository, IUnitOfWorkRepository unitOfWork) : IContactFormService
    {
        public async Task<ServiceResult<List<ContactFormResponse>>> GetAllAsync()
        {
            var contactForms = await contactFormRepository.GetAll().ToListAsync();

            var contactAsResponse = contactForms.Select(x=> new ContactFormResponse(
                x.Name,
                x.Email,
                x.Phone,
                x.Message,
                x.Company,
                x.CreatedAt)).ToList();

            return ServiceResult<List<ContactFormResponse>>.Success(contactAsResponse);
            
        }

        public async Task<ServiceResult> CreateAsync(CreateContactFormRequest request)
        {
            var contact = new ContactFormModel
            {
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                Message = request.Message,
                Company = request.Company,
                CreatedAt = DateTime.Now
            };
            await contactFormRepository.AddAsync(contact);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.OK);
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var contactFrom = await contactFormRepository.GetByIdAsync(id);

            if (contactFrom == null) return ServiceResult.Fail("Contact Form Not Found!", HttpStatusCode.NotFound);

            contactFormRepository.DeleteAsync(contactFrom);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult<List<ContactFormResponse>>> GetByCompanyNameAsync(string companyName)
        {
            var company = await contactFormRepository.GetByCompanyNameAsync(companyName);
            if (company == null) return ServiceResult<List<ContactFormResponse>>.Fail("Company Name Not Found!", HttpStatusCode.NotFound);

            var companyAsResponse = company.Select(x => new ContactFormResponse(
                x.Name,
                x.Email,
                x.Phone,
                x.Message,
                x.Company,
                x.CreatedAt)).ToList();

            return ServiceResult<List<ContactFormResponse>>.Success(companyAsResponse);
        }

        public async Task<ServiceResult<List<ContactFormResponse>>> GetByEmailAsync(string email)
        {
            var anyEmail = await contactFormRepository.GetByCompanyNameAsync(email);
            if (anyEmail == null) return ServiceResult<List<ContactFormResponse>>.Fail("Company Name Not Found!", HttpStatusCode.NotFound);

            var companyAsResponse = anyEmail.Select(x => new ContactFormResponse(
                x.Name,
                x.Email,
                x.Phone,
                x.Message,
                x.Company,
                x.CreatedAt)).ToList();

            return ServiceResult<List<ContactFormResponse>>.Success(companyAsResponse);
        }

        public async Task<ServiceResult<List<ContactFormResponse>>> GetByNameAsync(string name)
        {
            var anyName = await contactFormRepository.GetByCompanyNameAsync(name);
            if (anyName == null) return ServiceResult<List<ContactFormResponse>>.Fail("Company Name Not Found!", HttpStatusCode.NotFound);

            var companyAsResponse = anyName.Select(x => new ContactFormResponse(
                x.Name,
                x.Email,
                x.Phone,
                x.Message,
                x.Company,
                x.CreatedAt)).ToList();

            return ServiceResult<List<ContactFormResponse>>.Success(companyAsResponse);
        }
    }
}