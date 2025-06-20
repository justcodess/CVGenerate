namespace CVGenerate.Core.DTOs.Profile
{
    public class ProfileUpdateDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = null!;
        public bool IsVisible { get; set; }
    }
}