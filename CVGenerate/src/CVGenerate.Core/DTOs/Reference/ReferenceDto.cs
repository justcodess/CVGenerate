namespace CVGenerate.Core.DTOs.Reference;

public class ReferenceDto
{
    public string CompanyName { get; set; } = null!;
    public string ContactPerson { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public bool IsVisible { get; set; }
    public string? Hint { get; set; }
}