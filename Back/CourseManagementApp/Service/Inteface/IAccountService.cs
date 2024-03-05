using CourseManagementApp.DTO;
using CourseManagementApp.Model;
using Microsoft.AspNetCore.Identity;

namespace CourseManagementApp.Service.Inteface
{
    public interface IAccountService
    {
        Task<User> GetUserById(string id);
        Task<IdentityResult> RegisterMentorAsync(MentorRegistrationDTO userForRegistration);
    }
}
