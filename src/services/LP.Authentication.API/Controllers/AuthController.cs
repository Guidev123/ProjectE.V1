using LP.Authentication.API.DTO;
using LP.Authentication.API.Extensions;
using LP.Authentication.API.Extensions.JasonWebToken;
using LP.Shared.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace LP.Authentication.API.Controllers;

[Route("api/authentication")]
public class AuthController(IOptions<AppSettings> appSettings,
                      SignInManager<IdentityUser> signInManager,
                      UserManager<IdentityUser> userManager,
                      IJsonWebTokenHandler jwt) : MainController
{
    private readonly SignInManager<IdentityUser> _signInManager = signInManager;
    private readonly UserManager<IdentityUser> _userManager = userManager;
    private readonly IJsonWebTokenHandler _jwt = jwt;
    private readonly AppSettings _appSettings = appSettings.Value;

    [HttpPost("create")]
    public async Task<ActionResult> Register(UserRegisterDTO userRegister)
    {
        if(!ModelState.IsValid) return CustomResponse(ModelState);

        var user = new IdentityUser
        {
            UserName = userRegister.Email,
            Email = userRegister.Email,
            PhoneNumber = userRegister.Phone,
            EmailConfirmed = true
        };

        var result = await _userManager.CreateAsync(user, userRegister.Password);

        if (result.Succeeded) return CustomResponse(await _jwt.JwtGenerator(userRegister.Email));

        foreach(var identityError in result.Errors) AddError(identityError.Description);

        return CustomResponse();
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login(UserLoginDTO userLogin)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        var result = await _signInManager.PasswordSignInAsync(userLogin.Email, userLogin.Password, false, true);

        if (result.IsLockedOut)
        {
            AddError("Usuário bloqueado temporariamente, tente novamente mais tarde");
            return CustomResponse();
        }

        if(result.Succeeded) return CustomResponse(await _jwt.JwtGenerator(userLogin.Email));

        AddError("Usuário ou senha incorretos");
        return CustomResponse();
    }

    [HttpPut("change-password")]
    public async Task<ActionResult> ChangePassword(Guid id, ChangePasswordDTO changePassword)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);
        var user = await _userManager.FindByIdAsync(id.ToString());

        if (user is null)
        {
            AddError("Usuário não encontrado");
            return CustomResponse();
        }
        var result = await _userManager.ChangePasswordAsync(user, changePassword.CurrentPassword, changePassword.NewPassword);

        if (result.Succeeded) return CustomResponse(result);

        foreach (var error in result.Errors) AddError(error.Description);

        return CustomResponse();
    }
}
