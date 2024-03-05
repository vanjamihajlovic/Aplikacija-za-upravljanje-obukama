using CourseManagementApp.Model;

namespace CourseManagementApp.Service.Inteface
{
    public interface IAccountService
    {
        Task<User> GetUserById(string id);
    }
}
