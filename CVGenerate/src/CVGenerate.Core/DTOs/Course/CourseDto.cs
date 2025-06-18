namespace CVGenerate.Core.DTOs.Course;

public class CourseDto
{
    public string Name { get; set; } = null!;
    public string Institution { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Description { get; set; } = null!;
    public bool IsVisible { get; set; }
    public string? Hint { get; set; }
}