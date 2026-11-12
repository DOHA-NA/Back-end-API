
using System.ComponentModel.DataAnnotations.Schema;
namespace ApiCe.Core.Entites
{
    public class Student
    {
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public string? phone {get; set;}
        public string ? UserId { get; set; }

        public List<Enrollment> Enrollments { get; set; } = [];
    }
}
