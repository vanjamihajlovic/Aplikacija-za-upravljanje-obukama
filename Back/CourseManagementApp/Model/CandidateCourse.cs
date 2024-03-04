using System.ComponentModel.DataAnnotations;

namespace CourseManagementApp.Model
{

    public class CandidateCourse
    {
        [Required]
        public string CandidateId { get; set; }
        [Required]
        public User Candidate { get; set; }
        [Required]
        public Guid CourseId { get; set; }
        [Required]
        public Course Course { get; set; }
        public int ModulesFinished { get; set; }
        [MaxLength(1000)]
        public string FeedBack { get; set; }
        [Range(0, 10)]
        public int Grade { get; set; }
        public DateTime EndDate { get; set; }
    }
}
