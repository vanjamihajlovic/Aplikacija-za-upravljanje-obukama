using System.ComponentModel.DataAnnotations;

namespace CourseManagementApp.DTO
{
    public class UserLoginDTO
    {
        [Required(ErrorMessage = "Username is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
