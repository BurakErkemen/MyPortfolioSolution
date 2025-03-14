using Portfolio.Services.Services.ServicesForAboutMe.Certifications.Create;
using Portfolio.Services.Services.ServicesForAboutMe.Certifications.Update;

namespace Portfolio.Services.Services.ServicesForAboutMe.Certifications
{
    public interface ICertificationServices
    {
        Task<ServiceResult<List<CertificationResponse>>> GetAllAsync();
        Task<ServiceResult<CertificationResponse>> GetByIdAsync(int Id);
        Task<ServiceResult<CreateCertificationsResponse>> CreateAsync(CreateCertificationsRequest request);
        Task<ServiceResult> UpdateAsync(UpdateCertificationRequest request);
        Task<ServiceResult> DeleteAsync(int Id);

        Task<ServiceResult<List<CertificationResponse>>> CertificationGetByAboutIdAsync(int aboutId);
    }
}