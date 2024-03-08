using CourseManagementApp.Model;

namespace CourseManagementApp.DTO
{
    public class CourseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get ; set; }
        public string StartDateString { get; set; }
        public int Duration { get; set; }
        public int NumOfModules { get; set; }
        public Guid MentorId { get; set; }
        public List<CandidateDTO> Candidates { get; set; }

        public CourseDTO()
        {
            if (!string.IsNullOrEmpty(StartDateString) && DateTime.TryParse(StartDateString, out DateTime startDate))
            {
                StartDate = startDate;
            }
            // Optionally handle parsing errors or provide default behavior here
        }
    }
}
