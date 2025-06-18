namespace CVGenerate.Core.Entities;

public class Interest
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public string Hobby { get; set; } = null!;
    public bool IsVisible { get; set; } = true;
    public string? Hint { get; set; }
}