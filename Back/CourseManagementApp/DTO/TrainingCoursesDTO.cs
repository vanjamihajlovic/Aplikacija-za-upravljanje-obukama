namespace CourseManagementApp.DTO
{
    public class TrainingCoursesDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration { get; set; }
        public int NumOfModules { get; set; }
        public Guid MentorId { get; set; }
        public MentorDTO Mentor { get; set; }
        public List<CandidateDTO> Candidates { get; set; }
    }
}
