using Blend.IT.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blend.IT.Infra.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.UserName).HasMaxLength(200);
            builder.Property(c => c.Email).HasMaxLength(200);
            builder.Property(c => c.Password).HasMaxLength(200);

            builder.HasMany(c => c.UserProfiles).WithOne(e => e.User);
        }
    }
}
