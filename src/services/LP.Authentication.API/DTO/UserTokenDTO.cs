namespace LP.Authentication.API.DTO
{
    public record UserTokenDTO
    {
        public string? Id { get; set; }
        public string? Email { get; set; } 
        public IEnumerable<UserClaimDTO> Claims { get; set; } = null!;
    }
}
