namespace CourseManagementApp.DTO
{
    public class AuthenticateResponseDTO
    {
        public string AccessToken { get; set; }

        public DateTime AccessTokenExpirationDate { get; set; }

        public AuthenticateResponseDTO(string accessToken, DateTime accessTokenExpirationDate)
        {
            AccessToken = accessToken;
            AccessTokenExpirationDate = accessTokenExpirationDate;
        }
    }
}
