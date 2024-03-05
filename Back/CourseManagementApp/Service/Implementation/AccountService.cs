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
    }
}
