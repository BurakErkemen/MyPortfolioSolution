using Portfolio.Services.Services.ServicesForAboutMe.Skills.Create;
using Portfolio.Services.Services.ServicesForAboutMe.Skills.Update;

namespace Portfolio.Services.Services.ServicesForAboutMe.Skills
{
    public interface ISkillServices
    {
        Task<ServiceResult<List<SkillResponse>>> GetAllAsync();
        Task<ServiceResult<SkillResponse>> GetByIdAsync(int Id);
        Task<ServiceResult<CreateSkillsResponse>> CreateAsync(CreateSkillsRequest request);
        Task<ServiceResult> UpdateAsync(UpdateSkillsRequest request);
        Task<ServiceResult> DeleteAsync(int Id);
        Task<ServiceResult<List<SkillResponse>>> EducationGetByAboutIdAsync(int aboutId);
    }
}