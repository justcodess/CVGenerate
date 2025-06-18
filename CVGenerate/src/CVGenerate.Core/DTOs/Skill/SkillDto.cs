namespace CVGenerate.Core.DTOs.Skill;

public class SkillDto
{
    public string Name { get; set; } = null!;
    public string Level { get; set; } = null!; // Beginner, Intermediate, etc.
    public bool IsVisible { get; set; }
    public string? Hint { get; set; }
}