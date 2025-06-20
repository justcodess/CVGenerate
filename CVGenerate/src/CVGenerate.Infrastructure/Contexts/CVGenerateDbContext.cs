using CVGenerate.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CVGenerate.Infrastructure.Contexts
{
    public class CVGenerateDbContext : DbContext
    {
        public CVGenerateDbContext(DbContextOptions<CVGenerateDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Reference> References { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<PersonalInfo> PersonalInfos { get; set; }
        public DbSet<WebLink> WebLinks { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CustomSection> CustomSections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Fluent API'ler buraya gelecekse eklenebilir.
        }
    }
}