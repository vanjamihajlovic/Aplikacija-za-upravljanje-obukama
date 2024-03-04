using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManagementApp.Model
{

    public class CandidateCourse 
    {
        /*[Key]
        [Column(Order = 1)]*/
        public string CandidateId { get; set; }
        public User Candidate { get; set; }
        /*[Key]
        [Column(Order = 2)]*/
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        public string FeedBack { get; set; }
        public int Grade { get; set; }
    }
}
