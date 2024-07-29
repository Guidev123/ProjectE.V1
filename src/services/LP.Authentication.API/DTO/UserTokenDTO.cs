namespace LP.Authentication.API.DTO
{
    public record UserTokenDTO(string Id, string Email, IEnumerable<UserClaimDTO> Claims);
}
