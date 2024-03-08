using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CourseManagementApp.Model
{
    public class User : IdentityUser, IEntity<string>
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        public Role Role { get; set; }
        public ICollection<CandidateCourse> Courses { get; set; }
        public ICollection<Course> MentorCourses { get; set; }
    }
}
