namespace CoreApI.Server.Models
{
    public class RegsiterDTO
    {
        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }
    }
}
