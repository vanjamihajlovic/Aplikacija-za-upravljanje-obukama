using CourseManagementApp.DTO;

namespace CourseManagementApp.Service.Inteface
{
    public interface IUserService
    {
        List<MentorDTO> GetAllMentors();
        List<CandidateDTO> GetAllCandidates();



    }
}
