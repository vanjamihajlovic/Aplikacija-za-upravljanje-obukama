using CourseManagementApp.Model;
using System.ComponentModel.DataAnnotations;

namespace CourseManagementApp.DTO
{
    public class MentorDTO
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
