namespace CVGenerate.Core.DTOs.Profile
{
    public class ProfileCreateDto
    {
        public Guid UserId { get; set; }
        public string Description { get; set; } = null!;
        public bool IsVisible { get; set; }
    }
}