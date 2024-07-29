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
                      UserManager<IdentityUser> userManager,
                      IJwt jwt) : ControllerBase
{
    private readonly SignInManager<IdentityUser> _signInManager = signInManager;
    private readonly UserManager<IdentityUser> _userManager = userManager;
    private readonly IJwt _jwt = jwt;
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
            return Ok(await _jwt.JwtGenerator(userRegister.Email));
        }

        return Ok();
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login(UserLoginDTO userLogin)
    {
        if (!ModelState.IsValid) return BadRequest();

        var result = await _signInManager.PasswordSignInAsync(userLogin.Email, userLogin.Password, false, true);

        if (result.IsLockedOut)
        {
            return Ok(userLogin);
        }

        return Ok(await _jwt.JwtGenerator(userLogin.Email));
    }
}
