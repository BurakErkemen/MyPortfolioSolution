using Microsoft.EntityFrameworkCore;
using Portfolio.Repositories.Models.RepositoriesForAboutMe.AboutMe;
using Portfolio.Repositories.UnitOfWorkRepositories;
using Portfolio.Services.Services.ServicesForAboutMe.AboutMe.Create;
using Portfolio.Services.Services.ServicesForAboutMe.AboutMe.Update;
using System.Net;

namespace Portfolio.Services.Services.ServicesForAboutMe.AboutMe
{
    public class AboutMeServices(IAboutMeRepository aboutMeRepository, IUnitOfWorkRepository unitOfWork) : IAboutMeServices
    {
        public async Task<ServiceResult<List<AboutMeResponse>>> GetAllAsync()
        {
            var aboutMe = await aboutMeRepository.GetAll().ToListAsync();
            var aboutMeAsResponse = aboutMe.Select(a => new AboutMeResponse(
                a.FullName!,
                a.ContactNo!,
                a.Email!,
                a.CreatedAt,
                a.UserId)).ToList();

            return ServiceResult<List<AboutMeResponse>>.Success(aboutMeAsResponse);
        }

        public async Task<ServiceResult<AboutMeResponse>> GetByIdAsync(int id)
        {
            var aboutMe = await aboutMeRepository.GetByIdAsync(id);
            if (aboutMe == null) ServiceResult<AboutMeResponse>.Fail("About Me Paramaters is null!", HttpStatusCode.NotFound);

            var aboutMeResponse = new AboutMeResponse(
                aboutMe!.FullName!,
                aboutMe.ContactNo!,
                aboutMe.Email!,
                aboutMe.CreatedAt,
                aboutMe.UserId
                );

            return ServiceResult<AboutMeResponse>.Success(aboutMeResponse,HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult<CreateAboutMeResponse?>> CreateAsync(CreateAboutMeRequest request)
        {
            var anyAboutMe = await aboutMeRepository.Where(a => a.UserId == request.UserId).AnyAsync();

            if (anyAboutMe == true) 
                return ServiceResult<CreateAboutMeResponse?>.Fail("Bu kullanıcı için zaten bir AboutMe kaydı var.", HttpStatusCode.BadRequest);

            var AboutMe = new AboutMeModel
            {
                FullName = request.FullName,
                ContactNo = request.ContactNo,
                Email = request.Email,
                CreatedAt = DateTime.Now,
                UserId = request.UserId
            };

            await aboutMeRepository.AddAsync(AboutMe);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult<CreateAboutMeResponse?>.Success(
                new CreateAboutMeResponse(AboutMe.Id),HttpStatusCode.Created);
        }

        public async Task<ServiceResult> UpdateAsync(UpdateAboutMeRequest request)
        {
            var aboutMe = await aboutMeRepository.GetByIdAsync(request.Id);

            if (aboutMe == null) return ServiceResult.Fail("About Me Not Found!", HttpStatusCode.BadRequest);

            aboutMe.FullName = request.FullName;
            aboutMe.ContactNo = request.ContactNo;
            aboutMe.Email = request.Email;

            aboutMeRepository.UpdateAsync(aboutMe);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var anyAboutMe = await aboutMeRepository.GetByIdAsync(id);
            if (anyAboutMe == null)
                return ServiceResult.Fail("About Me not found!", HttpStatusCode.NotFound);

            aboutMeRepository.DeleteAsync(anyAboutMe);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult<AboutMeResponse>> GetByUserIdAsync(int userId)
        {
            var aboutMe = await aboutMeRepository.GetByUserIdAsync(userId);
            if (aboutMe == null)
                return ServiceResult<AboutMeResponse>.Fail("About Me Imformations Not Found!", HttpStatusCode.NotFound);

            var aboutMeAsResponse = new AboutMeResponse(
                aboutMe.FullName!,
                aboutMe.ContactNo!,
                aboutMe.Email!,
                aboutMe.CreatedAt,
                aboutMe.UserId);

            return ServiceResult<AboutMeResponse>.Success(aboutMeAsResponse);
        }
    }
}