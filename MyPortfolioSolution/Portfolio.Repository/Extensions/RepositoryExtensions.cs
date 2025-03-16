using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Portfolio.Repositories.Assembly;
using Portfolio.Repositories.GenericRepositories;
using Portfolio.Repositories.Models.Blog;
using Portfolio.Repositories.Models.ContactForms;
using Portfolio.Repositories.Models.RepositoriesForAboutMe.AboutMe;
using Portfolio.Repositories.Models.RepositoriesForAboutMe.Businesses;
using Portfolio.Repositories.Models.RepositoriesForAboutMe.Certifications;
using Portfolio.Repositories.Models.RepositoriesForAboutMe.Educations;
using Portfolio.Repositories.Models.RepositoriesForAboutMe.Skills;
using Portfolio.Repositories.Models.RepositoriesForAboutMe.SocialMediaUrls;
using Portfolio.Repositories.Models.Users;
using Portfolio.Repositories.UnitOfWorkRepositories;

namespace Portfolio.Repositories.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PortfolioDbContext>(options =>
            {
                var connectionString = configuration.GetSection
                (ConnectionStringOption.Key).Get<ConnectionStringOption>();

                options.UseSqlServer(connectionString!.SqlServer, sqlServerOptionsAction =>
                {
                    sqlServerOptionsAction.MigrationsAssembly(typeof(RepositoryAssembly).Assembly.FullName);
                });
            });


            // interface gördüğünde class'tan nesne üret
            // Scoped Response olduğunda nesneyi silmek için kullanılıyor.
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWorkRepository, UnitOfWorkRepository>();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IBlogRepository, BlogRepository>();

            services.AddScoped<IContactFormRepository, ContactFormRepository>();

            services.AddScoped<IAboutMeRepository, AboutMeRepository>();
            services.AddScoped<IBusinessRepository, BusinessRepository>();
            services.AddScoped<ICertificationRepository, CertificationRepository>();
            services.AddScoped<IEducationRepository, EducationRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<ISocialMediaRepository, SocialMediaRepository>();
            return services;
        }
    }
}