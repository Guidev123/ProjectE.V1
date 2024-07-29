using LP.Authentication.API.DTO;
using LP.Authentication.API.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LP.Authentication.API.Controllers;

[Route("api/authentication")]
[ApiController]
public class AuthController(IOptions<AppSettings> appSettings,
                      SignInManager<IdentityUser> signInManager,
                      UserManager<IdentityUser> userManager) : ControllerBase
{
    private readonly SignInManager<IdentityUser> _signInManager = signInManager;
    private readonly UserManager<IdentityUser> _userManager = userManager;
    private readonly AppSettings _appSettings = appSettings.Value;

    [HttpPost("create")]
    public async Task<ActionResult> Register(UserRegisterDTO userRegister)
    {
        if(!ModelState.IsValid) return BadRequest();

        var user = new IdentityUser
        {
            UserName = userRegister.Email,
            Email = userRegister.Email,
            PhoneNumber = userRegister.Phone,
            EmailConfirmed = true
        };

        var result = await _userManager.CreateAsync(user, userRegister.Password);

        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, false);
            return Ok();
        }

        return BadRequest();
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login(UserLoginDTO userLogin)
    {
        if (!ModelState.IsValid) return BadRequest();

        var result = await _signInManager.PasswordSignInAsync(userLogin.Email, userLogin.Password, false, true);

        if (result.Succeeded) return Ok();
        
        return BadRequest();
    }

    #region JwtCode
    private async Task<UserResponseDTO> JwtGenerator(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        var claims = await _userManager.GetClaimsAsync(user);
        var identityClaims = await GetUserClaims(claims, user);
        var encodedToken = EncodeToken(identityClaims);
        return GetTokenResponse(encodedToken, user, claims);
    }

    private async Task<ClaimsIdentity> GetUserClaims(ICollection<Claim> claims, IdentityUser user)
    {
        var userRoles = await _userManager.GetRolesAsync(user);

        claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
        claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));
        
        foreach (var userRole in userRoles)
        {
            claims.Add(new Claim("role", userRole));
        }

        var identityClaims = new ClaimsIdentity();
        identityClaims.AddClaims(claims);
        return identityClaims;
    }

    private string EncodeToken(ClaimsIdentity identityClaims)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
        {
            Issuer = _appSettings.ValidIssuer,
            Audience = _appSettings.ValidAudience,
            Subject = identityClaims,
            Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiresIn),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        });

        return tokenHandler.WriteToken(token);
    }

    private UserResponseDTO GetTokenResponse(string encodedToken, IdentityUser? user, IEnumerable<Claim> claims)
    {
        return new UserResponseDTO
        {
            AccessToken = encodedToken,
            ExpiresIn = TimeSpan.FromHours(_appSettings.ExpiresIn).TotalSeconds,
            UserToken = new UserTokenDTO
            {
                Id = user.Id,
                Email = user.Email,
                Claims = claims.Select(c => new UserClaimDTO { Type = c.Type, Value = c.Value })
            }
        };
    }
    private static long ToUnixEpochDate(DateTime date) =>
        (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

    #endregion
}
