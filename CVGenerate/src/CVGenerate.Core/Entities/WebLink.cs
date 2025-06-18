namespace CVGenerate.Core.Entities;

public class WebLink
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public string Url { get; set; } = null!;
    public string? PlatformName { get; set; }
    public bool IsVisible { get; set; } = true;
    public string? Hint { get; set; }
}