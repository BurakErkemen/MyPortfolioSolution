using Microsoft.EntityFrameworkCore;
using Portfolio.Repositories.Models.Users;


namespace Portfolio.Repositories
{
    public class PortfolioDbContext (DbContextOptions<PortfolioDbContext> options) : DbContext(options)
    {
        public DbSet<UserModel> Users { get; set; } = default!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

    }
}
