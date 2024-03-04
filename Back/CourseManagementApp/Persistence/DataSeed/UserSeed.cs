using CourseManagementApp.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementApp.Persistence.DataSeed
{
    public static class UserSeed
    {
        public static void SeedUsersAndRoles(this ModelBuilder modelBuilder)
        {
            var adminRole = new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "ADMINISTRATOR", NormalizedName = "ADMINISTRATOR" };
            var candidateRole = new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "CANDIDATE", NormalizedName = "CANDIDATE" };
            var mentorRole = new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "MENTOR", NormalizedName = "MENTOR" };
            modelBuilder.Entity<IdentityRole>().HasData(adminRole);
            modelBuilder.Entity<IdentityRole>().HasData(candidateRole);
            modelBuilder.Entity<IdentityRole>().HasData(mentorRole);
            var adminUser = new User
            {
                Id = Guid.NewGuid().ToString(),
                Role = Role.ADMINISTRATOR,
                FirstName = "ADMINISTRATOR",
                LastName = "ADMINISTRATOR",
                Email = "admin@mail.com",
                NormalizedEmail = "ADMIN@MAIL.COM",
                UserName = "admin@mail.com",
                NormalizedUserName = "ADMIN@MAIL.COM",
                PasswordHash = "AQAAAAEAACcQAAAAEEXFg5ruenEa0Y+RCZiUqAcckYMRnbx8+kg3PKkms3QPkRUfXdqZLPGWpFTu6fYmog=="
            };

            var candidateUser = new User
            {
                Id = Guid.NewGuid().ToString(),
                Role = Role.CANDIDATE,
                FirstName = "CANDIDATE",
                LastName = "CANDIDATE",
                Email = "candidate@mail.com",
                NormalizedEmail = "CANDIDATE@MAIL.COM",
                UserName = "candidate@mail.com",
                NormalizedUserName = "CANDIDATE@MAIL.COM",
                PasswordHash = "AQAAAAEAACcQAAAAEEXFg5ruenEa0Y+RCZiUqAcckYMRnbx8+kg3PKkms3QPkRUfXdqZLPGWpFTu6fYmog=="
            };

            var mentorUser = new User
            {
                Id = Guid.NewGuid().ToString(),
                Role = Role.MENTOR,
                FirstName = "MENTOR",
                LastName = "MENTOR",
                Email = "mentor@mail.com",
                NormalizedEmail = "MENTOR@MAIL.COM",
                UserName = "mentor@mail.com",
                NormalizedUserName = "MENTOR@MAIL.COM",
                PasswordHash = "AQAAAAEAACcQAAAAEEXFg5ruenEa0Y+RCZiUqAcckYMRnbx8+kg3PKkms3QPkRUfXdqZLPGWpFTu6fYmog=="
            };
            modelBuilder.Entity<User>().HasData(adminUser);
            modelBuilder.Entity<User>().HasData(candidateUser);
            modelBuilder.Entity<User>().HasData(mentorUser);
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> { UserId = adminUser.Id, RoleId = adminRole.Id });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> { UserId = candidateUser.Id, RoleId = candidateRole.Id });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> { UserId = mentorUser.Id, RoleId = mentorRole.Id });
        }
    }
}
