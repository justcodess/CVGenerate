namespace CVGenerate.Core.DTOs.Profile
{
    public class ProfileResponseDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Description { get; set; } = null!;
        public bool IsVisible { get; set; }
    }
}