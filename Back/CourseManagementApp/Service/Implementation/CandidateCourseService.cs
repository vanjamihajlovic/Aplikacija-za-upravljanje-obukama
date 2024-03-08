using AutoMapper;
using CourseManagementApp.DTO;
using CourseManagementApp.Model;
using CourseManagementApp.Service.Inteface;
using CourseManagementApp.UnitOfWork;
using Microsoft.AspNetCore.Identity;

namespace CourseManagementApp.Service.Implementation
{
    public class CandidateCourseService : ICandidateCourseService
    {
        private IUnitOfWork _unitOfWork;
        private UserManager<User> _userManager; 

        public CandidateCourseService(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<List<CandidateViewDTO>> GetAllCandidateCourseInfo(Guid courseId)
        {
            List<CandidateCourse> candidateCourses = _unitOfWork.CandidateCourseRepository.FindByCondition(c => c.CourseId == courseId).ToList();
            List<CandidateViewDTO> result = new List<CandidateViewDTO>();
            foreach(var candidateCourse in candidateCourses)
            {
                User candidate = await _userManager.FindByIdAsync(candidateCourse.CandidateId);
                Course course = await _unitOfWork.CourseRepository.GetByIdAsync(candidateCourse.CourseId);
                CandidateViewDTO candidateViewDTO = new CandidateViewDTO() { CourseDuration = course.Duration, 
                                                                             CourseStartDate = course.StartDate, 
                                                                             Feedback = candidateCourse.FeedBack, 
                                                                             Grade = candidateCourse.Grade, 
                                                                             Name = candidate.FirstName + " " + candidate.LastName };
                result.Add(candidateViewDTO);
            }

            return result;
        }
    }
}
