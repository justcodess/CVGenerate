namespace CVGenerate.Core.DTOs.WebLink;

public class WebLinkDto
{
    public string Url { get; set; } = null!;
    public string? PlatformName { get; set; }
    public bool IsVisible { get; set; }
    public string? Hint { get; set; }
}