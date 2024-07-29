namespace LP.Authentication.API.DTO
{
    public record UserResponseDTO(string AccessToken, double ExpiresIn, UserTokenDTO UsuarioToken);
}
