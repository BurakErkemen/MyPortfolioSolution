using Microsoft.EntityFrameworkCore;
using Portfolio.Repositories.Models.RepositoriesForAboutMe.Skills;
using Portfolio.Repositories.Models.RepositoriesForAboutMe.SocialMediaUrls;
using Portfolio.Repositories.UnitOfWorkRepositories;
using Portfolio.Services.Services.ServicesForAboutMe.SocialMediaUrls.Create;
using Portfolio.Services.Services.ServicesForAboutMe.SocialMediaUrls.Update;
using System.Net;

namespace Portfolio.Services.Services.ServicesForAboutMe.SocialMediaUrls
{
    public class SocialMediaServices(ISocialMediaRepository socialMediaRepository, IUnitOfWorkRepository unitOfWork) : ISocialMediaServices
    {
        public async Task<ServiceResult<SocialMediaResponse>> GetByIdAsync(int Id)
        {
            var social = await socialMediaRepository.GetByIdAsync(Id);

            if (social == null) return ServiceResult<SocialMediaResponse>.Fail("Links Not Found", HttpStatusCode.NotFound);

            var socialAsResponse = new SocialMediaResponse(
                social.Platform,
                social.URL,
                social.AboutMeId);

            return ServiceResult<SocialMediaResponse>.Success(socialAsResponse);
        }

        public async Task<ServiceResult<List<SocialMediaResponse>>> GetAllAsync()
        {
            var social = await socialMediaRepository.GetAll().ToListAsync();

            var socialAsResponse = social.Select(s => new SocialMediaResponse(
                s.Platform,
                s.URL,
                s.AboutMeId)).ToList();

            return ServiceResult<List<SocialMediaResponse>>.Success(socialAsResponse);
        }

        public async Task<ServiceResult<CreateSocialMediaResponse>> CreateAsync(CreateSocialMediaRequest request)
        {
            var create = new SocialMediaModel
            {
                Platform = request.Platform,
                URL = request.URL,
                AboutMeId = request.AboutMeId
            };

            await socialMediaRepository.AddAsync(create);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult<CreateSocialMediaResponse>.Success(new CreateSocialMediaResponse(create.Id), HttpStatusCode.Created);
        }

        public async Task<ServiceResult> UpdateAsync(UpdateSocialMediaRequest request)
        {
            var anyLink = await socialMediaRepository.GetByIdAsync(request.Id);

            if (anyLink is null)
                return ServiceResult.Fail("Links Not Found!", HttpStatusCode.NotFound);

            anyLink.Platform = request.Platform;
            anyLink.URL = request.URL;

            socialMediaRepository.UpdateAsync(anyLink);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult> DeleteAsync(int Id)
        {
            var anyLink = await socialMediaRepository.GetByIdAsync(Id);

            if (anyLink is null)
                return ServiceResult.Fail("Link Not Found!", HttpStatusCode.NotFound);

            socialMediaRepository.DeleteAsync(anyLink);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult<List<SocialMediaResponse>>> SocialGetByAboutIdAsync(int aboutId)
        {
            var links = await socialMediaRepository.GetByAboutMeIdAsync(aboutId);

            if (links is null)
                return ServiceResult<List<SocialMediaResponse>>.Fail("Links Not Found!", HttpStatusCode.NotFound);

            var linksAsResponse = links.Select(s => new SocialMediaResponse(
                s.Platform,
                s.URL,
                s.AboutMeId)).ToList();

            return ServiceResult<List<SocialMediaResponse>>.Success(linksAsResponse);
        }
    }
}
