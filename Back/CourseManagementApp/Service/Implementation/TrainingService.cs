using AutoMapper;
using CourseManagementApp.DTO;
using CourseManagementApp.Model;
using CourseManagementApp.Service.Inteface;
using CourseManagementApp.UnitOfWork;

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
            int i = 0;
            foreach (CourseDTO courseDTO in trainingDTO.Courses)
            {   
                foreach (CandidateDTO candidateDTO in courseDTO.Candidates)
                {
                    var candidateCourse = new CandidateCourse() { CandidateId = candidateDTO.Id.ToString(), CourseId = addedTraining.Courses.ElementAt(i).Id };
                    await _unitOfWork.CandidateCourseRepository.Add(candidateCourse);
                }
                i++;
            }
            await _unitOfWork.CompleteAsync();
        }

        public List<AllTrainingsResponseDTO> GetAllTrainings()
        {
            List<AllTrainingsResponseDTO> allTrainings = _mapper.Map<List<AllTrainingsResponseDTO>>(_unitOfWork.TrainingRepository.GetAll());
            return allTrainings;
        }

        public async Task<TrainingDTO> GetTrainingById(Guid id)
        {
           TrainingDTO trainingDTO = _mapper.Map<TrainingDTO>(await _unitOfWork.TrainingRepository.GetByIdAsync(id));
           return trainingDTO;
        }
    }
}
