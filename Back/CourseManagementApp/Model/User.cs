using Microsoft.AspNetCore.Identity;

namespace CourseManagementApp.Model
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string Password { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public ICollection<CandidateCourse> Courses { get; set; }
    }
}
