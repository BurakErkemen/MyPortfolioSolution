using Portfolio.Repositories.Models.RepositoriesForAboutMe.Educations;
using Portfolio.Repositories.UnitOfWorkRepositories;
using Portfolio.Services.Services.ServicesForAboutMe.Educations.Create;
using Portfolio.Services.Services.ServicesForAboutMe.Educations.Update;

namespace Portfolio.Services.Services.ServicesForAboutMe.Educations
{
    public class EducationServices(IEducationRepository educationRepository, IUnitOfWorkRepository unitOfWork) : IEducationServices
    {
        public Task<ServiceResult<EducationResponse>> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ServiceResult>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<CreateEducationResponse>> CreateAsync(CreateEducationRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> UpdateAsync(UpdateEducationRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<List<EducationResponse>>> EducationGetByAboutIdAsync(int aboutId)
        {
            throw new NotImplementedException();
        }
    }
}
