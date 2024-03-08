using AutoMapper;
using CourseManagementApp.DTO;
using CourseManagementApp.Model;
using CourseManagementApp.Service.Inteface;
using CourseManagementApp.UnitOfWork;
using Microsoft.AspNetCore.Identity;

namespace CourseManagementApp.Service.Implementation
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;    

        public CourseService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        public List<CourseDTO> GetAllCoursesByMentorId(string mentorId)
        {
            List<Course> coursesByMentor =  _unitOfWork.CourseRepository.FindByCondition(x => x.MentorId == mentorId).ToList();
            List<CourseDTO> coursesDto = _mapper.Map<List<CourseDTO>>(coursesByMentor);
            return coursesDto;
        }

        public async Task<List<TrainingCoursesDTO>> GetAllCoursesByTrainingId(Guid trainingId)
        {
            List<Course> coursesByMentor = _unitOfWork.CourseRepository.FindByCondition(x => x.Training.Id == trainingId).ToList();
            List<TrainingCoursesDTO> coursesDto = _mapper.Map<List<TrainingCoursesDTO>>(coursesByMentor);
            foreach(TrainingCoursesDTO course in coursesDto)
            {
                course.Mentor = _mapper.Map<MentorDTO>(await _userManager.FindByIdAsync(course.MentorId.ToString()));
            }
            return coursesDto;
        }
    }
}
