using CourseManagementApp.DTO;

namespace CourseManagementApp.Service.Inteface
{
    public interface ITrainingService
    {
        Task AddTraining(TrainingDTO trainingDTO);
    }
}
