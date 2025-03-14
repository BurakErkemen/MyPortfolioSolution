using Microsoft.EntityFrameworkCore;
using Portfolio.Repositories.Models.RepositoriesForAboutMe.Educations;
using Portfolio.Repositories.UnitOfWorkRepositories;
using Portfolio.Services.Services.ServicesForAboutMe.Educations.Create;
using Portfolio.Services.Services.ServicesForAboutMe.Educations.Update;
using System.Net;

namespace Portfolio.Services.Services.ServicesForAboutMe.Educations
{
    public class EducationServices(IEducationRepository educationRepository, IUnitOfWorkRepository unitOfWork) : IEducationServices
    {
        public async Task<ServiceResult<EducationResponse>> GetByIdAsync(int Id)
        {
            var anyEducation = await educationRepository.GetByIdAsync(Id);
            if (anyEducation is null) return ServiceResult<EducationResponse>.Fail("Education Information Not Found!",HttpStatusCode.NotFound);

            var educationAsResponse = new EducationResponse(
                anyEducation.SchoolName,
                anyEducation.Degree,
                anyEducation.FieldOfStudy,
                anyEducation.StartDate,
                anyEducation.EndDate,
                anyEducation.AboutMeId);

            return ServiceResult<EducationResponse>.Success(educationAsResponse);
        }

        public async Task<ServiceResult<List<EducationResponse>>> GetAllAsync()
        {
            var education = await educationRepository.GetAll().ToListAsync();
            
            var educationAsResponse = education.Select(e => new EducationResponse(
                e.SchoolName,
                e.Degree,
                e.FieldOfStudy,
                e.StartDate,
                e.EndDate,
                e.AboutMeId)).ToList();

            return ServiceResult<List<EducationResponse>>.Success(educationAsResponse);
        }

        public async Task<ServiceResult<CreateEducationResponse>> CreateAsync(CreateEducationRequest request)
        {
            var education = new EducationModel
            {
                SchoolName = request.SchoolName,
                Degree = request.Degree,
                FieldOfStudy = request.FieldOfStudy,
                StartDate = request.StardDate,
                EndDate = request.EndDate,
                AboutMeId = request.AboutMeId
            };

            await educationRepository.AddAsync(education);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult<CreateEducationResponse>.Success(new CreateEducationResponse(education.Id), HttpStatusCode.Created);
        }

        public async Task<ServiceResult> UpdateAsync(UpdateEducationRequest request)
        {
            var anyEducation = await educationRepository.GetByIdAsync(request.Id);
            if (anyEducation is null) return ServiceResult.Fail("Education Information Not Found!", HttpStatusCode.NotFound);

            anyEducation!.SchoolName = request.SchoolName;
            anyEducation.Degree = request.Degree;
            anyEducation.FieldOfStudy = request.FieldOfStudy;
            anyEducation.StartDate = request.StartDate;
            anyEducation.EndDate = request.EndDate;

            educationRepository.UpdateAsync(anyEducation);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult> DeleteAsync(int Id)
        {
            var anyEducation = await educationRepository.GetByIdAsync(Id);

            if (anyEducation is null)
                return ServiceResult.Fail("Education Information Not Found!", HttpStatusCode.NotFound);

            educationRepository.DeleteAsync(anyEducation);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult<List<EducationResponse>>> EducationGetByAboutIdAsync(int aboutId)
        {
            var education = await educationRepository.GetByAboutMeIdAsync(aboutId);

            if (!education.Any())
                return ServiceResult<List<EducationResponse>>.Fail("Education Information Not Found!", HttpStatusCode.NotFound);

            var educationAsResponse = education.Select(e => new EducationResponse(
                e.SchoolName,
                e.Degree,
                e.FieldOfStudy,
                e.StartDate,
                e.EndDate,
                e.AboutMeId
                )).ToList();

            return ServiceResult<List<EducationResponse>>.Success(educationAsResponse);
        }
    }
}