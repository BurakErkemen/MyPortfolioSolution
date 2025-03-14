using Portfolio.Services.Services.ServicesForAboutMe.Educations.Create;
using Portfolio.Services.Services.ServicesForAboutMe.Educations.Update;

namespace Portfolio.Services.Services.ServicesForAboutMe.Educations
{
    public interface IEducationServices
    {
        Task<List<ServiceResult>> GetAllAsync();
        Task<ServiceResult<EducationResponse>> GetByIdAsync(int Id);
        Task<ServiceResult<CreateEducationResponse>> CreateAsync(CreateEducationRequest request);
        Task<ServiceResult> UpdateAsync(UpdateEducationRequest request);
        Task<ServiceResult> DeleteAsync(int Id);
        Task<ServiceResult<List<EducationResponse>>> EducationGetByAboutIdAsync(int aboutId);
    }
}
