using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementApp.Persistence.DataSeed
{
    public static class RoleSeed
    {
        public static void SeedRoles(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "ADMINISTRATOR", NormalizedName = "ADMINISTRATOR" });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "CANDIDATE", NormalizedName = "CANDIDATE" });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "MENTOR", NormalizedName = "MENTOR" });
        }
    }
}
