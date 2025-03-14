using Microsoft.EntityFrameworkCore;
using Portfolio.Repositories.Models.RepositoriesForAboutMe.Certifications;
using Portfolio.Repositories.UnitOfWorkRepositories;
using Portfolio.Services.Services.ServicesForAboutMe.Certifications.Create;
using Portfolio.Services.Services.ServicesForAboutMe.Certifications.Update;
using System.Net;

namespace Portfolio.Services.Services.ServicesForAboutMe.Certifications
{
    public class EducationServices(ICertificationRepository certificationRepository, IUnitOfWorkRepository unitOfWork) : ICertificationServices
    {
        public async Task<ServiceResult<List<CertificationResponse>>> GetAllAsync()
        {
            var certification = await certificationRepository.GetAll().ToListAsync();
            var certificationAsResponse = certification.Select(c => new CertificationResponse
            (
                c.Title,
                c.IssuingOrganization,
                c.IssuedDate,
                c.ExpirationDate,
                c.AboutMeId)).ToList();
            
            return ServiceResult<List<CertificationResponse>>.Success(certificationAsResponse);
        }

        public async Task<ServiceResult<CertificationResponse>> GetByIdAsync(int Id)
        {
            var certification = await certificationRepository.GetByIdAsync(Id);

            if (certification == null)
                return ServiceResult<CertificationResponse>.Fail("Certification Not Found!", HttpStatusCode.NotFound);

            var certificationAsResponse = new CertificationResponse(
                certification.Title,
                certification.IssuingOrganization,
                certification.IssuedDate,
                certification.ExpirationDate,
                certification.AboutMeId);

            return ServiceResult<CertificationResponse>.Success(certificationAsResponse);
        }

        public async Task<ServiceResult<CreateCertificationsResponse>> CreateAsync(CreateCertificationsRequest request)
        {
            var certification = new CertificationModel 
            { 
                Title = request.Title,
                IssuingOrganization = request.IssuingOrganization,
                IssuedDate = request.IssuedDate,
                ExpirationDate = request.ExpirationDate,
                AboutMeId = request.AboutMeId
            };
            
            await certificationRepository.AddAsync(certification);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult<CreateCertificationsResponse>.Success(new CreateCertificationsResponse(certification.Id), HttpStatusCode.Created);
        }

        public async Task<ServiceResult> UpdateAsync(UpdateCertificationRequest request)
        {
            var anyCertification = await certificationRepository.GetByIdAsync(request.Id);

            if (anyCertification == null)
                return ServiceResult.Fail("Certification Not Found!", HttpStatusCode.NotFound);

            anyCertification.Title = request.Title;
            anyCertification.IssuingOrganization = request.IssuingOrganization;
            anyCertification.IssuedDate = request.IssuedDate;
            anyCertification.ExpirationDate = request.ExpirationDate;

            certificationRepository.UpdateAsync(anyCertification);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult> DeleteAsync(int Id)
        {
            var anyCertification = await certificationRepository.GetByIdAsync(Id);

            if (anyCertification == null)
                return ServiceResult.Fail("Certification Not Found!", HttpStatusCode.NotFound);
            
            certificationRepository.DeleteAsync(anyCertification);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult<List<CertificationResponse>>> CertificationGetByAboutIdAsync(int aboutId)
        {
            var certification = await certificationRepository.GetByAboutMeIdAsync(aboutId);

            if (!certification.Any())
                return ServiceResult<List<CertificationResponse>>.Fail("Certification Not Found!", HttpStatusCode.NotFound);

            var certificaitonAsResponse = certification.Select(c => new CertificationResponse(
            c.Title,
            c.IssuingOrganization,
            c.IssuedDate,
            c.ExpirationDate,
            c.AboutMeId)).ToList();

            return ServiceResult<List<CertificationResponse>>.Success(certificaitonAsResponse);
        }
    }
}
