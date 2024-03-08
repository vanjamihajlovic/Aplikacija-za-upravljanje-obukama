using CourseManagementApp.DTO;

namespace CourseManagementApp.Service.Inteface
{
    public interface ICourseService
    {
        List<CourseDTO> GetAllCoursesByMentorId(string mentorId);
        Task<List<TrainingCoursesDTO>> GetAllCoursesByTrainingId(Guid trainingId);
    }
}
