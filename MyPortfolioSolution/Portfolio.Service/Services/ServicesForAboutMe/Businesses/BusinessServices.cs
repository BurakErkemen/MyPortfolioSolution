using Microsoft.EntityFrameworkCore;
using Portfolio.Repositories.Models.RepositoriesForAboutMe.Businesses;
using Portfolio.Repositories.UnitOfWorkRepositories;
using Portfolio.Services.Services.ServicesForAboutMe.Businesses.Create;
using Portfolio.Services.Services.ServicesForAboutMe.Businesses.Update;
using System.Net;

namespace Portfolio.Services.Services.ServicesForAboutMe.Businesses
{
    public class BusinessServices(IBusinessRepository businessRepository, IUnitOfWorkRepository unitOfWork) : IBusinessServices
    {
        public async Task<ServiceResult<List<BusinessResponse>>> GetAllAsync()
        {
            var business = await businessRepository.GetAll().ToListAsync();

            var businessAsResponse = business.Select(b => new BusinessResponse
            (b.CompanyName,
            b.Position,
            b.StartDate,
            b.EndDate,
            b.AboutMeId)).ToList();

            return ServiceResult<List<BusinessResponse>>.Success(businessAsResponse);
        }

        public async Task<ServiceResult<BusinessResponse>> GetByIdAsync(int Id)
        {
            var business = await businessRepository.GetByIdAsync(Id);

            if (business == null)
                return ServiceResult<BusinessResponse>.Fail("Business Information Not Found!", HttpStatusCode.NotFound);

            var businessAsResponse = new BusinessResponse
            (business.CompanyName,
            business.Position,
            business.StartDate,
            business.EndDate,
            business.AboutMeId);

            return ServiceResult<BusinessResponse>.Success(businessAsResponse, HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult<CreateBusinessResponse>> CreateAsync(CreateBusinessRequest request)
        {
            var business = new BusinessModel
            {
                CompanyName = request.CompanyName,
                Position = request.Position,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                AboutMeId = request.AboutMeId
            };

            await businessRepository.AddAsync(business);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult<CreateBusinessResponse>.Success(new CreateBusinessResponse(business.Id), HttpStatusCode.Created);
        }
        public async Task<ServiceResult> UpdateAsync(UpdateBusinessRequest request)
        {
            var anyBusiness = await businessRepository.GetByIdAsync(request.Id);
            if (anyBusiness == null)
                return ServiceResult.Fail("Business Layer Not Found!", HttpStatusCode.NotFound);

            anyBusiness.CompanyName = request.CompanyName;
            anyBusiness.Position = request.Position;
            anyBusiness.StartDate = request.StartDate;
            anyBusiness.EndDate = request.EndDate;

            businessRepository.UpdateAsync(anyBusiness);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult> DeleteAsync(int Id)
        {
            var anyBusiness = await businessRepository.GetByIdAsync(Id);
            if (anyBusiness == null)
                return ServiceResult.Fail("Any Business Not Found!", HttpStatusCode.NotFound);

            businessRepository.DeleteAsync(anyBusiness);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult<List<BusinessResponse>>> BusinessGetByAboutIdAsync(int aboutId)
        {
            var businesses = await businessRepository.GetByAboutMeIdAsync(aboutId);

            if (!businesses.Any())
                return ServiceResult<List<BusinessResponse>>.Fail("Your Business Information Not Found!", HttpStatusCode.NotFound);

            var response = businesses.Select(b => new BusinessResponse(
                b.CompanyName,
                b.Position,
                b.StartDate,
                b.EndDate,
                b.AboutMeId
            )).ToList();

            return ServiceResult<List<BusinessResponse>>.Success(response);
        }
    }
}
