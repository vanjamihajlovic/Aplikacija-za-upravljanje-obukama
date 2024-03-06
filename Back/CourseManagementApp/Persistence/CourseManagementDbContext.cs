using CourseManagementApp.Model;
using CourseManagementApp.Persistence.DataSeed;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementApp.Persistence
{
    public class CourseManagementDbContext : IdentityDbContext
    {
        public CourseManagementDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<CandidateCourse> CandidateCourses { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<CandidateCourse>()
                .HasKey(cc => cc.Id);

            builder.Entity<CandidateCourse>()
                .HasOne(cc => cc.Course)
                .WithMany(c => c.CandidatesEnrolled)
                .HasForeignKey(cc => cc.CourseId)
                .OnDelete(DeleteBehavior.NoAction); 

            builder.Entity<CandidateCourse>()
                .HasOne(cc => cc.Candidate)
                .WithMany(c => c.Courses)
                .HasForeignKey(cc => cc.CandidateId)
                .OnDelete(DeleteBehavior.Cascade); 

            /*builder.Entity<Course>()
            .HasOne<User>(c => c.Mentor)
            .WithMany(m => m.MentorCourses)
            .HasForeignKey(c => c.Mentor);*/


            builder.SeedUsersAndRoles();
        }
    }
}
