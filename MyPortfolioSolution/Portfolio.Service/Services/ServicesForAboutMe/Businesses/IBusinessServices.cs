using Portfolio.Services.Services.ServicesForAboutMe.Businesses.Create;
using Portfolio.Services.Services.ServicesForAboutMe.Businesses.Update;

namespace Portfolio.Services.Services.ServicesForAboutMe.Businesses
{
    public interface IBusinessServices
    {
        Task<ServiceResult<List<BusinessResponse>>> GetAllAsync();
        Task<ServiceResult<BusinessResponse>> GetByIdAsync(int Id);
        Task<ServiceResult<CreateBusinessResponse>> CreateAsync(CreateBusinessRequest request);
        Task<ServiceResult> UpdateAsync(UpdateBusinessRequest request);
        Task<ServiceResult> DeleteAsync(int Id);
        Task<ServiceResult<List<BusinessResponse>>> BusinessGetByAboutIdAsync(int aboutId);
    }
}