using Blend.IT.Domain.Models;
using Blend.IT.Infra.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blend.IT.Infra
{
    public class BlendITContext : DbContext
    {
        public BlendITContext(DbContextOptions<BlendITContext> options) : base(options)
        {
        }

        public DbSet<User> Users{ get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserProfileConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
        }
    }
}
