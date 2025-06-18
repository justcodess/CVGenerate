namespace CVGenerate.Core.Entities;

public class Course
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public string Name { get; set; } = null!;
    public string Institution { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Description { get; set; } = null!;
    public bool IsVisible { get; set; } = true;
    public string? Hint { get; set; }
}