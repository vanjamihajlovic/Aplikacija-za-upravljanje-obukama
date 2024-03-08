using CourseManagementApp.Model;
using CourseManagementApp.Repository;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementApp.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DbContext _dbContext;
        public IGenericRepository<Training, Guid> TrainingRepository { get; set; }
        public IGenericRepository<Course, Guid> CourseRepository { get; set; }
        public IGenericRepository<CandidateCourse, Guid> CandidateCourseRepository { get; set; }

        public UnitOfWork(DbContext dbContext, IGenericRepository<Training, Guid> trainingRepository,
                                               IGenericRepository<Course, Guid> courseRepository,
                                               IGenericRepository<CandidateCourse, Guid> candidateCourseRepository)
        {
            _dbContext = dbContext;
            TrainingRepository = trainingRepository;
            CourseRepository = courseRepository;
            CandidateCourseRepository = candidateCourseRepository;
        }

        public async Task CompleteAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void DetachAll()
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries())
            {
                entry.State = EntityState.Detached;
            }
        }
    }
}
