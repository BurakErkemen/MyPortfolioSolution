﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portfolio.Repositories.Models.Educations
{
    public class EducationConfiguration : IEntityTypeConfiguration<EducationModel>
    {
        public void Configure(EntityTypeBuilder<EducationModel> builder)
        {
            throw new NotImplementedException();
        }
    }
}
