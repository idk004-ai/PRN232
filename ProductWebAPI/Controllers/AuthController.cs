using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using BusinessObjects.Constants;
using BusinessObjects.Helpers;
using BusinessObjects.Interfaces.IServices;
using BusinessObjects.Models.Configs;
using BusinessObjects.Models.DTOs;
using BusinessObjects.Models.DTOs.Auth;


namespace ProductWebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IOptions<JwtConfig> jwtConfig, IUserService userService,
    IIdentityService identityService, ITokenService tokenService, IEmailService emailService) : ControllerBase
{
    private readonly JwtConfig _jwtConfig = jwtConfig.Value;
    private readonly IUserService _userService = userService;
    private readonly IIdentityService _identityService = identityService;
    private readonly ITokenService _tokenService = tokenService;
    private readonly IEmailService _emailService = emailService;

    [HttpPost("login")]
    public async Task<IActionResult> Authenticate([FromBody] LoginDTO loginDTO)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        await _identityService.SigninUserAsync(loginDTO);
        var tokenDTO = await _userService
            .CreateAuthTokenAsync(EmailHelper.GetUsername(loginDTO.Email),
             _jwtConfig.RefreshTokenValidityInDays);
        _tokenService.SetTokensInsideCookie(tokenDTO, HttpContext);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Message = "Login successfully"
        });
    }

    [HttpPost("login-google")]
    public async Task<IActionResult> GoogleAuthenticate(ExternalAuthDTO externalAuth)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var user = await _userService.FindOrCreateUserAsync(externalAuth, [UserRole.USER]);
        var tokenDTO = await _userService
            .CreateAuthTokenAsync(user!.Username, _jwtConfig.RefreshTokenValidityInDays);
        _tokenService.SetTokensInsideCookie(tokenDTO, HttpContext);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Message = "Login successfully"
        });
    }

    [HttpPost("register")]
    public async Task<ActionResult<string>> Register([FromBody] RegisterDTO registerDTO)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        await _identityService.HandleExistingUserAsync(registerDTO.Email);
        await _identityService.CreateUserAsync(registerDTO, [UserRole.USER]);
        var token = await _emailService.SendEmailConfirmationAsync(registerDTO.Email, Request);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Message = "Registration successful, please check your email to confirm your account",
            Data = token
        });
    }
    [HttpGet("confirm-email")]
    public async Task<IActionResult> ConfirmEmail([FromQuery] string token, [FromQuery] string email)
    {
        await _identityService.ConfirmEmailAsync(email, token);
        return Redirect($"{_jwtConfig.Audience}/auth/signin");
    }
    [HttpGet("refresh-token")]
    public async Task<IActionResult> RefreshToken()
    {
        var refeshToken = _tokenService.GetTokenInsideCookie(_jwtConfig.RefreshTokenKey, HttpContext);
        var tokenDTO = await _userService.RefeshAuthTokenAsync(refeshToken);
        _tokenService.SetTokensInsideCookie(tokenDTO, HttpContext);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Message = "Refresh Token Successfully!"
        });
    }

    [HttpPost("forgot-password")]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDTO forgotPasswordDTO)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        await _userService.CheckEmailExistedAsync(forgotPasswordDTO.Email);
        await _emailService.SendEmailConfirmationForgotPasswordAsync(forgotPasswordDTO.Email, Request);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Message = "Please check your email to reset your password",
        });
    }


    [HttpPost("change-password")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO changePasswordDTO)
    {
        await _userService.ResetPasswordAsync(changePasswordDTO);
        return Ok(new Response
        {
            Status = ResponseStatus.SUCCESS,
            Message = "Password changed successfully"
        });
    }
}