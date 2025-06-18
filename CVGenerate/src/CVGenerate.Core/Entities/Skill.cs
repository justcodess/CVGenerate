namespace CVGenerate.Core.Entities;

using CVGenerate.Core.Enums;

public class Skill
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public string Name { get; set; } = null!;
    public SkillLevel Level { get; set; }
    public bool IsVisible { get; set; } = true;
    public string? Hint { get; set; }
}