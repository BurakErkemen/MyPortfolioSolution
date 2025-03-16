using Microsoft.EntityFrameworkCore;
using Portfolio.Repositories.Models.Blog;
using Portfolio.Repositories.Models.ContactForms;


namespace Portfolio.Repositories
{
    public class PortfolioDbContext (DbContextOptions<PortfolioDbContext> options) : DbContext(options)
    {
        public DbSet<BlogModel> Blogs { get; set; }

        public DbSet<ContactFormModel> ContactForms { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
