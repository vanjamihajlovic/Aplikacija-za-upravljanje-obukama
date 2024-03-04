using CourseManagementApp.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

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
                .HasKey(cc => new { cc.CandidateId, cc.CourseId});
            builder.Entity<CandidateCourse>()
                .HasOne(cc => cc.Course)
                .WithMany(c => c.CandidatesEnrolled)
                .HasForeignKey(cc => cc.CourseId);
            builder.Entity<CandidateCourse>()
                .HasOne(cc => cc.Candidate)
                .WithMany(c => c.Courses)
                .HasForeignKey(cc => cc.CandidateId);


            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "ADMINISTRATOR", NormalizedName = "ADMINISTRATOR" });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "CANDIDATE", NormalizedName = "CANDIDATE" });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "MENTOR", NormalizedName = "MENTOR" });
        }
    }
}
