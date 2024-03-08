namespace CourseManagementApp.DTO
{
    public class CandidateViewDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Feedback { get; set; }
        public int? CourseDuration { get; set; }
        public DateTime CourseStartDate { get; set; }
        public int Grade { get; set; }
    }
}
