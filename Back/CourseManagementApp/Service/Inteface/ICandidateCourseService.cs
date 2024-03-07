using CourseManagementApp.DTO;
using Microsoft.AspNetCore.Identity;

namespace CourseManagementApp.Service.Inteface
{
    public interface ICandidateCourseService
    {
        Task<List<CandidateViewDTO>> GetAllCandidateCourseInfo(Guid courseId);
    }
}
