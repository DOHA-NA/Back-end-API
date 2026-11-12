namespace ApiCe.Core.Entites
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string Role { get; set; } = "Student";

        public int? StudentId { get; set; }

        public Student? Student { get; set; }
    }
}