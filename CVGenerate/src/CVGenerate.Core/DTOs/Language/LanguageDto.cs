namespace CVGenerate.Core.DTOs.Language;

public class LanguageDto
{
    public string Name { get; set; } = null!;
    public string Level { get; set; } = null!; // A1–C2, Native, etc.
    public bool IsVisible { get; set; }
    public string? Hint { get; set; }
}