using CourseManagementApp.Model;
using System.IdentityModel.Tokens.Jwt;

namespace CourseManagementApp.Util
{
    public interface IJwtUtils
    {
        string? ValidateJwtToken(string token);
        Task<JwtSecurityToken> CreateTokenAsync(User? user);
    }
}
