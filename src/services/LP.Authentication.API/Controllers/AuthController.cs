using LP.Authentication.API.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LP.Authentication.API.Controllers;

[Route("api/authentication")]
[ApiController]
public class AuthController(SignInManager<IdentityUser> signManager,
                      UserManager<IdentityUser> userManager) : ControllerBase
{
    private readonly SignInManager<IdentityUser> _signManager = signManager;
    private readonly UserManager<IdentityUser> _userManager = userManager;

    [HttpPost("create-account")]
    public async Task<ActionResult> Register(UserRegisterDTO userRegister)
    {
        if(!ModelState.IsValid) return BadRequest();

        var user = new IdentityUser
        {
            UserName = userRegister.Email,
            Email = userRegister.Email,
            EmailConfirmed = true
        };

        var result = await _userManager.CreateAsync(user, userRegister.Password);

        if (result.Succeeded)
        {
            await _signManager.SignInAsync(user, false);
            return Ok();
        }

        return BadRequest();
    }

    [HttpPost("authenticate-account")]
    public async Task<ActionResult> Login(UserLoginDTO userLogin)
    {
        if (!ModelState.IsValid) return BadRequest();

        var result = await _signManager.PasswordSignInAsync(userLogin.Email, userLogin.Password, false, true);

        if (result.Succeeded)
        {
            return Ok();
        }
        return BadRequest();
    }
}
