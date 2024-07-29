namespace LP.Authentication.API.DTO
{
    public record UserResponseDTO
    {
        public string AccessToken { get; set; } = string.Empty;
        public UserTokenDTO UserToken { get; set; } = null!;
        public double ExpiresIn { get; set; }
    }
}
