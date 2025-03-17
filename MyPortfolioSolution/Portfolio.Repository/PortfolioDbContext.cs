using Microsoft.EntityFrameworkCore;
using Portfolio.Repositories.Models.Blog.BlogCategory;
using Portfolio.Repositories.Models.Blog.BlogPost;
using Portfolio.Repositories.Models.Blog.BlogTag;
using Portfolio.Repositories.Models.ContactForms;
using Portfolio.Repositories.Models.User;


namespace Portfolio.Repositories
{
    public class PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : DbContext(options)
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<BlogPostModel> BlogPosts { get; set; }
        public DbSet<BlogTagModel> BlogTags { get; set; }
        public DbSet<BlogCategoryModel> BlogCategories { get; set; }

        public DbSet<ContactFormModel> ContactForms { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
