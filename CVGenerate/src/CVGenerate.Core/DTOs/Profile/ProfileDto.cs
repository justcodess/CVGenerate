namespace CVGenerate.Core.DTOs.Profile;

public class ProfileDto
{
    public string Description { get; set; } = null!;
    public bool IsVisible { get; set; }
    public string? Hint { get; set; }
}