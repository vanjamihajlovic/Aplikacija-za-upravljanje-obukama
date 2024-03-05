using CourseManagementApp.DTO;
using CourseManagementApp.Model;
using CourseManagementApp.Service.Inteface;
using Microsoft.AspNetCore.Identity;

namespace CourseManagementApp.Service.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;

        public AccountService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<User> GetUserById(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            return user;
        }

        public async Task<IdentityResult> RegisterMentorAsync(MentorRegistrationDTO userForRegistration)
        {
            var user = new User() { FirstName = userForRegistration.Name, LastName = userForRegistration.Surname, Email = userForRegistration.Email, UserName = userForRegistration.Email, Role = Role.MENTOR };
            var result = await _userManager.CreateAsync(user, userForRegistration.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "MENTOR");
            }
            return result;
        }
    }
}
