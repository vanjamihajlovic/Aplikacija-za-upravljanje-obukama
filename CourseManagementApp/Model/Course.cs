using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CourseManagementApp.Model
{
    public class Course : IEntity<Guid>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumOfModules { get; set; }
        public DateTime Deadline { get; set; }
        public User Mentor { get; set; }
        public ICollection<CandidateCourse> CandidatesEnrolled { get; set; }  
        public Training Training { get; set; }
    }
}
