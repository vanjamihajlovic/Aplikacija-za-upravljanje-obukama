using System.ComponentModel.DataAnnotations;

namespace CourseManagementApp.DTO
{
    public class TrainingDTO
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        public List<CourseDTO> Courses {get; set;}
    }
}
