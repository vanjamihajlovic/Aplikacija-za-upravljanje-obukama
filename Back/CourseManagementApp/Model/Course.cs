using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CourseManagementApp.Model
{
    public class Course : IEntity<Guid>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
        [Required]
        public int NumOfModules { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public int Duration { get; set; }
        public User Mentor { get; set; }
        public string MentorId { get; set; }
        public virtual ICollection<CandidateCourse> CandidatesEnrolled { get; set; }  
        public Training Training { get; set; }
    }
}
