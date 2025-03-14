using Microsoft.EntityFrameworkCore;
using Portfolio.Repositories.Models.RepositoriesForAboutMe.Skills;
using Portfolio.Repositories.UnitOfWorkRepositories;
using Portfolio.Services.Services.ServicesForAboutMe.Skills.Create;
using Portfolio.Services.Services.ServicesForAboutMe.Skills.Update;
using System.Net;

namespace Portfolio.Services.Services.ServicesForAboutMe.Skills
{
    public class SkillServices(ISkillRepository skillRepository, IUnitOfWorkRepository unitOfWork) : ISkillServices
    {
        public async Task<ServiceResult<SkillResponse>> GetByIdAsync(int Id)
        {
            var anySkills = await skillRepository.GetByIdAsync(Id);

            if (anySkills is null)
                return ServiceResult<SkillResponse>.Fail("Skill Not Found!", HttpStatusCode.NotFound);

            var skillResponse = new SkillResponse(
                anySkills.Name,
                anySkills.Level,
                anySkills.AboutMeId
                );

            return ServiceResult<SkillResponse>.Success(skillResponse);
        }

        public async Task<ServiceResult<List<SkillResponse>>> GetAllAsync()
        {
            var skill = await skillRepository.GetAll().ToListAsync();

            var skillAsResponse = skill.Select(s => new SkillResponse(
                s.Name,
                s.Level,
                s.AboutMeId)).ToList();

            return ServiceResult<List<SkillResponse>>.Success(skillAsResponse);
        }

        public async Task<ServiceResult<CreateSkillsResponse>> CreateAsync(CreateSkillsRequest request)
        {
            var skills = new SkillModel
            {
                Name = request.Name,
                Level = request.Level,
                AboutMeId = request.AboutMeId,
            };

            await skillRepository.AddAsync(skills);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult<CreateSkillsResponse>.Success(new CreateSkillsResponse(skills.Id), HttpStatusCode.Created);
        }

        public async Task<ServiceResult> UpdateAsync(UpdateSkillsRequest request)
        {
            var skills = await skillRepository.GetByIdAsync(request.Id);

            if (skillRepository is null)
                return ServiceResult.Fail("Skills Not Found!", HttpStatusCode.NotFound);

            skills!.Name = request.Name;
            skills.Level = request.Level;

            skillRepository.UpdateAsync(skills);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult> DeleteAsync(int Id)
        {
            var anySkill = await skillRepository.GetByIdAsync(Id);

            if (anySkill is null)
                return ServiceResult.Fail("Skill Information Not Found!", HttpStatusCode.NotFound);

            skillRepository.DeleteAsync(anySkill);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult<List<SkillResponse>>> EducationGetByAboutIdAsync(int aboutId)
        {
            var skill = await skillRepository.GetByAboutMeIdAsync(aboutId);

            if (skill is null)
                return ServiceResult<List<SkillResponse>>.Fail("Skill Information Not Found!", HttpStatusCode.NotFound);

            var skillAsResponse = skill.Select(s => new SkillResponse(
                s.Name,
                s.Level,
                s.AboutMeId)).ToList();

            return ServiceResult<List<SkillResponse>>.Success(skillAsResponse);
        }
    }
}
