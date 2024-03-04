using CourseManagementApp.DTO;
using CourseManagementApp.Exceptions;
using CourseManagementApp.Model;
using CourseManagementApp.Service.Inteface;
using CourseManagementApp.Util;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace CourseManagementApp.Service.Implementation
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly IJwtUtils _jwtUtils;

        public UserAuthenticationService(UserManager<User> userManager, IJwtUtils jwtUtils)
        {
            _userManager = userManager;
            _jwtUtils = jwtUtils;
        }

        private async Task<AuthenticateResponseDTO> CreateAuthenticateResponse(User? user)
        {
            var accessToken = await _jwtUtils.CreateTokenAsync(user);
            DateTime validTo = accessToken.ValidTo;
            string accessTokenSerialized = new JwtSecurityTokenHandler().WriteToken(accessToken);
            return new AuthenticateResponseDTO(accessTokenSerialized,  validTo);
        }

        public async Task<AuthenticateResponseDTO?> ValidateUserLogin(UserLoginDTO loginDto)
        { 
            User user = await _userManager.FindByEmailAsync(loginDto.Email);
            var validCredentials = user != null && await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!validCredentials)
            {
                throw new LoginException();
            }
            return await CreateAuthenticateResponse(user);
        }
    }
}
