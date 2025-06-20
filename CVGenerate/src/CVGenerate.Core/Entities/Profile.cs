namespace CVGenerate.Core.Entities
{
    public class Profile
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; } // Foreign Key
        public string Description { get; set; } = null!;

        // Navigation
        public User User { get; set; } = null!;
        public bool IsVisible { get; set; }
    }
}