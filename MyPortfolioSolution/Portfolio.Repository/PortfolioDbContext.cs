using Microsoft.EntityFrameworkCore;
using Portfolio.Repositories.Models.ContactForms;
using Portfolio.Repositories.Models.RepositoriesForAboutMe.AboutMe;
using Portfolio.Repositories.Models.RepositoriesForAboutMe.Businesses;
using Portfolio.Repositories.Models.RepositoriesForAboutMe.Certifications;
using Portfolio.Repositories.Models.RepositoriesForAboutMe.Educations;
using Portfolio.Repositories.Models.RepositoriesForAboutMe.Skills;
using Portfolio.Repositories.Models.RepositoriesForAboutMe.SocialMediaUrls;
using Portfolio.Repositories.Models.Users;


namespace Portfolio.Repositories
{
    public class PortfolioDbContext (DbContextOptions<PortfolioDbContext> options) : DbContext(options)
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<ContactFormModel> ContactForms { get; set; }
        public DbSet<AboutMeModel> AboutMe { get; set; }
        public DbSet<EducationModel> Educations { get; set; }
        public DbSet<BusinessModel> Businesses { get; set; }
        public DbSet<SkillModel> Skills { get; set; }
        public DbSet<CertificationModel> Certifications { get; set; }
        public DbSet<SocialMediaModel> SocialMediaLinks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

    }
}
