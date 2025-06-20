using Microsoft.EntityFrameworkCore;
using CVGenerate.Core.Entities;

namespace CVGenerate.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<WorkExperience> WorkExperiences => Set<WorkExperience>();
    public DbSet<Education> Educations => Set<Education>();
    public DbSet<Skill> Skills => Set<Skill>();
    public DbSet<Language> Languages => Set<Language>();
    public DbSet<Reference> References => Set<Reference>();
    public DbSet<Interest> Interests => Set<Interest>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<WebLink> WebLinks => Set<WebLink>();
    public DbSet<Profile> Profiles => Set<Profile>();
    public DbSet<PersonalInfo> PersonalInfos => Set<PersonalInfo>();
    public DbSet<CustomSection> CustomSections => Set<CustomSection>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}