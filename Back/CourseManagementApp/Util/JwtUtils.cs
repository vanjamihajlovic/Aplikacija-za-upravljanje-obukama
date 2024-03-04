using CourseManagementApp.Model;
using CourseManagementApp.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CourseManagementApp.Util
{
    public class JwtUtils : IJwtUtils
    {
        private readonly UserManager<User> _userManager;
        private readonly JwtOptions _jwtOptions;

        public JwtUtils(UserManager<User> userManager, IOptions<JwtOptions> options)
        {
            _userManager = userManager;
            _jwtOptions = options.Value;

        }

        public async Task<JwtSecurityToken> CreateTokenAsync(User? user)
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaim(user);
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return tokenOptions;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_jwtOptions.SecretKey);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaim(User? user)
        {
            var claims = new List<Claim>
        {
            new Claim("id", user.Id)
        };
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken
            (
            issuer: _jwtOptions.ValidIssuer,
            audience: _jwtOptions.ValidAudience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtOptions.JwtExpiresInMinutes)),
            signingCredentials: signingCredentials
            );
            return tokenOptions;
        }

        public string? ValidateJwtToken(string token)
        {
            if (token == null)
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtOptions.SecretKey);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = jwtToken.Claims.First(x => x.Type == "id").Value;
                return userId;
            }
            catch (Exception ex)
            {
                return null;
                //throw new InvalidTokenException("Invalid token(s)", ex);
            }
        }
    }
}
