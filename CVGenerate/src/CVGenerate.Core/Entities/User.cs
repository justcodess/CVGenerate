namespace CVGenerate.Core.Entities;

using CVGenerate.Core.Enums;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public Role Role { get; set; } = Role.User;

    public PersonalInfo? PersonalInfo { get; set; }
    public Profile? Profile { get; set; }
    public List<WebLink> WebLinks { get; set; } = new();
    public List<WorkExperience> WorkExperiences { get; set; } = new();
    public List<Education> Educations { get; set; } = new();
    public List<Skill> Skills { get; set; } = new();
    public List<Interest> Interests { get; set; } = new();
    public List<Reference> References { get; set; } = new();
    public List<Language> Languages { get; set; } = new();
    public List<Course> Courses { get; set; } = new();
    public List<CustomSection> CustomSections { get; set; } = new();
}