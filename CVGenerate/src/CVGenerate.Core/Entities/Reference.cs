namespace CVGenerate.Core.Entities;

public class Reference
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public string CompanyName { get; set; } = null!;
    public string ContactPerson { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public bool IsVisible { get; set; } = true;
    public string? Hint { get; set; }
}