using Portfolio.Services.Services.ServicesForAboutMe.Educations.Create;
using Portfolio.Services.Services.ServicesForAboutMe.Educations.Update;

namespace Portfolio.Services.Services.ServicesForAboutMe.Certifications
{
    public interface IEdutionServices
    {
        Task<List<ServiceResult>> GettAllAsync();
        Task<ServiceResult<EducationResponse>> GetById(int Id);
        Task<ServiceResult<CreateEducationResponse>> CreateAsync(CreateEducationRequest request);
        Task<ServiceResult> UpdateAsync(UpdateEducationRequest request);
        Task<ServiceResult> DeleteAsync(int Id);
        Task<ServiceResult<List<EducationResponse>>> EducationGetByAboutIdAsync();
    }
}
