using LP.Authentication.API.DTO;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace LP.Authentication.API.Extensions
{
    public interface IJwt
    {
        Task<UserResponseDTO> JwtGenerator(string email);
        Task<ClaimsIdentity> GetUserClaims(ICollection<Claim> claims, IdentityUser user);
        string EncodeToken(ClaimsIdentity identityClaims);
        UserResponseDTO GetTokenResponse(string encodedToken, IdentityUser? user, IEnumerable<Claim> claims);
    }
}
