using LP.Authentication.API.DTO;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace LP.Authentication.API.Extensions.JasonWebToken
{
    public interface IJsonWebTokenHandler
    {
        Task<UserResponseDTO> JwtGenerator(string email);
        Task<ClaimsIdentity> GetUserClaims(ICollection<Claim> claims, IdentityUser user);
        string EncodeToken(ClaimsIdentity identityClaims);
        UserResponseDTO GetTokenResponse(string encodedToken, IdentityUser? user, IEnumerable<Claim> claims);
    }
}
