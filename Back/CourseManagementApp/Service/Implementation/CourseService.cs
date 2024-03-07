using AutoMapper;
using CourseManagementApp.DTO;
using CourseManagementApp.Model;
using CourseManagementApp.Service.Inteface;
using CourseManagementApp.UnitOfWork;

namespace CourseManagementApp.Service.Implementation
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CourseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<CourseDTO> GetAllCoursesByMentorId(string mentorId)
        {
            List<Course> coursesByMentor =  _unitOfWork.CourseRepository.FindByCondition(x => x.MentorId == mentorId).ToList();
            List<CourseDTO> coursesDto = _mapper.Map<List<CourseDTO>>(coursesByMentor);
            return coursesDto;
        }
    }
}
