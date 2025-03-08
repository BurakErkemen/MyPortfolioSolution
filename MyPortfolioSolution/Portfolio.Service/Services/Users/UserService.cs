using Microsoft.EntityFrameworkCore;
using Portfolio.Repositories.Models.Users;
using Portfolio.Repositories.UnitOfWorkRepositories;
using Portfolio.Services.Services.Users.Create;
using Portfolio.Services.Services.Users.Update;
using System.Net;

namespace Portfolio.Services.Services.Users
{
    public class UserService(IUserRepository userRepository, IUnitOfWorkRepository unitOfWork) : IUserService
    {
        public async Task<ServiceResult> DeactivateAccountAsync(UpdateUserRequest request) // Hesabı pasif hale getir.
        {
            var user = await userRepository.GetByEmailAsync(request.Email);
            if (user == null) return ServiceResult.Fail("User not found", HttpStatusCode.NotFound);

            // Kullanıcının hesabını pasif hale getir
            user.IsActivate = request.AccountStatus;
            userRepository.UpdateAsync(user);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }
        public async Task<ServiceResult> ReactivateAccountAsync(UpdateUserRequest request) // Hesabı tekrar aktif hale getir.
        {
            var user = await userRepository.GetByEmailAsync(request.Email);
            if (user == null) return ServiceResult.Fail("User not found!", HttpStatusCode.NotFound);

            // Kullanıcının hesabını aktif hale getir 
            user.IsActivate = request.AccountStatus;
            userRepository.UpdateAsync(user);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }
        public async Task<ServiceResult> UpdateUserRoleAsync(UpdateUserRequest request) // Admin, yazar gibi rolleri güncelle.
        {
            var user = await userRepository.GetByIdAsync(request.Id);
            if (user == null) return ServiceResult.Fail("User not found!", HttpStatusCode.NotFound);

            // Rol güncelleme
            user.Role = request.Role;
            userRepository.UpdateAsync(user);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }
        public async Task<ServiceResult<List<UserResponse>>> GetAllAsync()
        {
            var user = await userRepository.GetAll().ToListAsync();

            var userAsResponse = user.Select(x => new UserResponse
            (x.Name,
            x.PhotoURL,
            x.Email,
            x.Role,
            x.IsActivate,
            x.CreatedAt
            )).ToList();

            return ServiceResult<List<UserResponse>>.Success(userAsResponse);
        }
        public async Task<ServiceResult<UserResponse?>> GetByIdAsync(int id)
        {
            var user = await userRepository.GetByIdAsync(id);
            if (user == null) return ServiceResult<UserResponse?>.Fail("User Not Found!", HttpStatusCode.NotFound);

            var userAsResponse = new UserResponse
                (user.Name,
                user.PhotoURL,
                user.Email,
                user.Role,
                user.IsActivate,
                user.CreatedAt);

            return ServiceResult<UserResponse?>.Success(userAsResponse);

        }

        public async Task<ServiceResult<List<UserResponse>>> GetByNameAsync(string Name)
        {
            var user = await userRepository.GetByNameAsync(Name);
            if (user == null) return ServiceResult<List<UserResponse>>.Fail("User Not Found!", HttpStatusCode.NotFound);

            var userAsResponse = user.Select(x => new UserResponse
            (x.Name,
            x.PhotoURL,
            x.Email,
            x.Role,
            x.IsActivate,
            x.CreatedAt
            )).ToList();

            return ServiceResult<List<UserResponse>>.Success(userAsResponse);
        }

        public async Task<ServiceResult<CreateUserResponse?>> CreateAsync(CreateUserRequest request)
        {
            var anyUser = await userRepository.IsEmailTakenAsync(request.Email);
            if (anyUser == true) return ServiceResult<CreateUserResponse?>.Fail("User's email already exists!", HttpStatusCode.BadRequest);

            var user = new UserModel
            {
                Name = request.Name,
                Email= request.Email,
                Password= request.Password,
                Role = UserRoles.User,
                IsActivate = AccountStatus.Active,
                CreatedAt= DateTime.Now
            };

            await userRepository.AddAsync(user);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult<CreateUserResponse?>.Success(
                new CreateUserResponse(user.Id),HttpStatusCode.Created);
        }
        public async Task<ServiceResult> UpdateAsync(UpdateUserRequest request)
        {
            var user = await userRepository.GetByIdAsync(request.Id);
            if (user == null) return ServiceResult.Fail("User Not Found!", HttpStatusCode.BadRequest);
            
            user.Name = request.Name;
            user.Email = request.Email;
            user.Password = request.Password;
            user.Role = request.Role;
            user.IsActivate = request.AccountStatus;

            userRepository.UpdateAsync(user);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }
        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var anyUser = await userRepository.GetByIdAsync(id);
            if (anyUser == null) return ServiceResult.Fail("User Not Found!",HttpStatusCode.NotFound);

            userRepository.DeleteAsync(anyUser);
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Success(HttpStatusCode.NoContent);
        }
    }
}
