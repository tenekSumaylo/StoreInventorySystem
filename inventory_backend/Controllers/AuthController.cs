using FluentValidation;
using inventory_backend.Authentication;
using inventory_backend.Dtos;
using inventory_backend.Exceptions;
using inventory_backend.Models;
using inventory_backend.Services.AuthServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace inventory_backend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService<LoginDto, RegisterDto> _basicAuthenticationService;
        IAuthenticationService<AuthenticateResult, ExternalLoginInfo> _googleOten;

        private readonly IValidator<LoginDto> _loginValidator;
        private readonly IValidator<RegisterDto> _registerValidator;
        private readonly SignInManager<Customer> _signinManager;

        public AuthController( IValidator<LoginDto> loginValidator, IAuthenticationService<LoginDto, RegisterDto> basicService
            , IValidator<RegisterDto> registerValidator, SignInManager<Customer> signinManager,
            IAuthenticationService<AuthenticateResult, ExternalLoginInfo>  service)
        {
            _loginValidator = loginValidator;
            _basicAuthenticationService = basicService;
            _registerValidator = registerValidator;
            _signinManager = signinManager;
            _googleOten = service;
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
                return Ok(new { jwtToken } );
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
            var properties = _signinManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);
            return new ChallengeResult("Google", properties);
        }

        [HttpGet("GoogleCallBack")]
        public async Task<IActionResult> GoogleCallBack()
        {
            var nota = await _signinManager.GetExternalAuthenticationSchemesAsync();
            var externalInfo = await _signinManager.GetExternalLoginInfoAsync();
            var context = await HttpContext.AuthenticateAsync("Google");
            var name = context?.Principal?.FindFirstValue(ClaimTypes.Email);
            if ( externalInfo is null )
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
