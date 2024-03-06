using AutoMapper;
using CourseManagementApp.DTO;
using CourseManagementApp.Model;
using CourseManagementApp.Service.Inteface;
using CourseManagementApp.UnitOfWork;
using Microsoft.AspNetCore.Identity;

namespace CourseManagementApp.Service.Implementation
{
    public class TrainingService : ITrainingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public TrainingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddTraining(TrainingDTO trainingDTO)
        {
            Training training = _mapper.Map<Training>(trainingDTO);
            Training addedTraining = await _unitOfWork.TrainingRepository.Add(training);
            foreach(CourseDTO courseDTO in trainingDTO.Courses)
            {
                Course newCourse = _mapper.Map<Course>(courseDTO);
                newCourse.Training = addedTraining;
                newCourse.MentorId = courseDTO.MentorId.ToString();
                Course addedCourse = await _unitOfWork.CourseRepository.Add(newCourse);
                foreach (CandidateDTO candidateDTO in courseDTO.Candidates)
                {
                    var candidateCourse = new CandidateCourse() { CandidateId = candidateDTO.Id.ToString(), CourseId = addedCourse.Id };
                    await _unitOfWork.CandidateCourseRepository.Add(candidateCourse);
                }
            }
            await _unitOfWork.CompleteAsync();
        }
    }
}
