namespace CVGenerate.Core.DTOs.WorkExperience;

public class WorkExperienceDto
{
    public string JobTitle { get; set; } = null!;
    public string Company { get; set; } = null!;
    public string City { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Description { get; set; } = null!;
    public bool IsVisible { get; set; }
    public string? Hint { get; set; }
}