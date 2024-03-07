using CourseManagementApp.Model;
using CourseManagementApp.Repository;

namespace CourseManagementApp.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IGenericRepository<Training, Guid> TrainingRepository { get; }
        public IGenericRepository<Course, Guid> CourseRepository { get; }
        public IGenericRepository<CandidateCourse, Guid> CandidateCourseRepository { get; }
        Task CompleteAsync();
        void DetachAll();
    }
}
