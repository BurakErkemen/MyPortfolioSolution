using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portfolio.Repositories.Models.AboutMe
{
    public class AboutMeConfiguration : IEntityTypeConfiguration<AboutMeModel>
    {
        public void Configure(EntityTypeBuilder<AboutMeModel> builder)
        {
            throw new NotImplementedException();
        }
    }
}
