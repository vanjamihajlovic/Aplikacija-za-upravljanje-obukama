using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManagementApp.Model
{

    public class CandidateCourse : IEntity<Guid>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string CandidateId { get; set; }
        public User Candidate { get; set; }
        [Required]
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        public int ModulesFinished { get; set; }
        [MaxLength(1000)]
        public string? FeedBack { get; set; }
        [Range(0, 10)]
        public int Grade { get; set; }
        public DateTime EndDate { get; set; }
    }
}
