using Portfolio.Services.Services.ServicesForAboutMe.AboutMe.Create;
using Portfolio.Services.Services.ServicesForAboutMe.AboutMe.Update;

namespace Portfolio.Services.Services.ServicesForAboutMe.AboutMe
{
    public interface IAboutMeServices
    {
        Task<ServiceResult<List<AboutMeResponse>>> GetAllAsync();
        Task<ServiceResult<AboutMeResponse>> GetByIdAsync(int id);
        Task<ServiceResult<CreateAboutMeResponse?>> CreateAsync(CreateAboutMeRequest request);
        Task<ServiceResult> UpdateAsync(UpdateAboutMeRequest request);
        Task<ServiceResult> DeleteAsync(int id);
        Task<ServiceResult<AboutMeResponse>> GetByUserIdAsync(int userId);
    }
}