using CourseManagementApp.DTO;

namespace CourseManagementApp.Service.Inteface
{
    public interface IUserAuthenticationService
    {
        Task<AuthenticateResponseDTO?> ValidateUserLogin(UserLoginDTO loginDto);
    }
}
