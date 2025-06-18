namespace CVGenerate.Core.Entities;

public class WorkExperience
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public string JobTitle { get; set; } = null!;
    public string Company { get; set; } = null!;
    public string City { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Description { get; set; } = null!;
    public bool IsVisible { get; set; } = true;
    public string? Hint { get; set; }
}