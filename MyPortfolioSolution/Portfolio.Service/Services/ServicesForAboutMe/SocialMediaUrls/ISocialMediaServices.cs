using Portfolio.Services.Services.ServicesForAboutMe.SocialMediaUrls.Create;
using Portfolio.Services.Services.ServicesForAboutMe.SocialMediaUrls.Update;

namespace Portfolio.Services.Services.ServicesForAboutMe.SocialMediaUrls
{
    public interface ISocialMediaServices
    {
        Task<ServiceResult<List<SocialMediaResponse>>> GetAllAsync();
        Task<ServiceResult<SocialMediaResponse>> GetByIdAsync(int Id);
        Task<ServiceResult<CreateSocialMediaResponse>> CreateAsync(CreateSocialMediaRequest request);
        Task<ServiceResult> UpdateAsync(UpdateSocialMediaRequest request);
        Task<ServiceResult> DeleteAsync(int Id);
        Task<ServiceResult<List<SocialMediaResponse>>> SocialGetByAboutIdAsync(int aboutId);
    }
}
