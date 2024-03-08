using System.ComponentModel.DataAnnotations;

namespace CourseManagementApp.DTO
{
    public class AllTrainingsResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
