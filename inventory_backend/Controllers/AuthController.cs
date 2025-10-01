using FluentValidation;
using inventory_backend.Authentication;
using inventory_backend.Authentication.GoogleAuthentication;
using inventory_backend.Dtos;
using inventory_backend.Exceptions;
using inventory_backend.Roles;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace inventory_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService<LoginDto, RegisterDto> _basicAuthenticationService;
        private readonly IGoogleAuthenticationService _googleService;
        private readonly IValidator<LoginDto> _loginValidator;
        private readonly IValidator<RegisterDto> _registerValidator;

        public AuthController( IValidator<LoginDto> loginValidator, IAuthenticationService<LoginDto, RegisterDto> basicService
            , IValidator<RegisterDto> registerValidator,
            IGoogleAuthenticationService service)
        {
            _loginValidator = loginValidator;
            _basicAuthenticationService = basicService;
            _registerValidator = registerValidator;
            _googleService = service;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            try
            {
                if (await _loginValidator.ValidateAsync(dto) is FluentValidation.Results.ValidationResult validator 
                    && !validator.IsValid)
                {
                    throw new LoginException("Login dto is invalid...", validator);
                }
                var jwtToken = ( await _basicAuthenticationService.Login(dto) ) ?? throw new LoginException("Jwt token is invalid, and cannot be processed");
                Response.Cookies.Append("jwt-auth", jwtToken, new CookieOptions
                {
                    Secure = true,
                    HttpOnly = true,
                    Expires = DateTime.UtcNow.AddDays(1)
                });
                return Ok(new { Succeeded = jwtToken != null } );
            }
            catch (LoginException ex)
            {
                return BadRequest(ex.ValidationResult?.Errors is null ? new {ex.Message} : new {ex.ValidationResult.Errors});
            }
            catch (Exception ex)
            {
                return BadRequest(new {ex.Message});
            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            try
            {
                if (_registerValidator.Validate(dto) is FluentValidation.Results.ValidationResult validationResult
                    && !validationResult.IsValid )
                {
                    throw new RegisterException("Register data has invalid fields", validationResult);
                }
                var result = await _basicAuthenticationService.CreateUser(dto);
                return Ok(new {result.Succeeded, Message="Registration Successful"});
            }
            catch (RegisterException ex)
            {
                return BadRequest(ex.IdentityResult?.Errors is null ? new {ex.ValidationResult!.Errors} : new {ex.IdentityResult.Errors});
            }
            catch (Exception ex)
            {
                return BadRequest(new {ex.Message});
            }
        }

        [HttpGet("Google")]
        public IActionResult GoogleLogin()
        {
            var redirectUrl = Url.Action(
                    action: "GoogleCallBack",
                    controller: "Auth",
                    values: new {ReturnUrl = "http://localhost:5166/swagger" }
            );
            var properties = _googleService.ConfigureExternal("Google", redirectUrl!);
            return new ChallengeResult("Google", properties);
        }

        [HttpGet("GoogleCallBack")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GoogleCallBack()
        {
            try
            {
                var info = await _googleService.GetExternalInformation();
                if (info is null)
                {
                    throw new LoginException("Google login failed...");
                }
                
                var tryCreate = await _googleService.CreateUser(info) ?? throw new LoginException("Identity result cannot be configured... and unknown");
                var authData = await HttpContext.AuthenticateAsync("Google");
                var token = await _googleService.Login(authData) ?? throw new LoginException("Login failure, token not found");
                Response.Cookies.Append("jwt-auth", token, new CookieOptions
                {
                    Secure = true,
                    HttpOnly = true,
                    Expires = DateTime.UtcNow.AddDays(1)
                });
                return Ok("Login successful");
            }
            catch ( LoginException ex )
            {
                return BadRequest( new { ex.Message } );  
            }
            catch ( Exception ex )
            {
                return BadRequest( new { ex.Message, ex.StackTrace } );
            }
        }

        [HttpGet("Check")]
        [Authorize]
        public IActionResult CheckLogin()
        {
            var role = User.FindFirstValue(ClaimTypes.Role);
            if ( role is null )
            {
                return BadRequest("Roles non existent");
            }
            return Ok( new { IsEmployee = role.Equals(AppRoles.Employee), IsCustomer = role.Equals(AppRoles.Customer)});
        }
    }
}
