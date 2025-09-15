using FluentValidation;
using inventory_backend.Dtos;
using inventory_backend.Exceptions;
using inventory_backend.Services.AuthServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace inventory_backend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;
        private readonly IValidator<LoginDto> _loginValidator;

        public AuthController(IAuthService service, IValidator<LoginDto> loginValidator)
        {
            _auth = service;
            _loginValidator = loginValidator;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            try
            {
                if (await _loginValidator.ValidateAsync(dto) is FluentValidation.Results.ValidationResult validator && !validator.IsValid)
                {
                    throw new LoginException("Login dto is invalid...", validator);
                }
                return Ok(await _auth.Login(dto));
            }
            catch (LoginException ex)
            {
                return BadRequest(ex.ValidationResult?.Errors is null ? ex.Message : ex.ValidationResult.Errors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            try
            {
                var result = await _auth.Register(dto);
                return Ok(result.Succeeded);
            }
            catch (RegisterException ex)
            {
                return BadRequest(ex.IdentityResult?.Errors is null ? ex.ValidationResult!.Errors : ex.IdentityResult.Errors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Google")]
        [AllowAnonymous]
        public IActionResult ExternalLogin(string provider, string? returnUrl = null)
        {
            var redirectUrl = Url.Action(
                action: "ExternalLoginCallback",
                controller: "Auth",
                values: new { ReturnUrl = returnUrl });
            var properties = _auth.ConfigureExternalLogin(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string? returnUrl = null, string? remoteError = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if ( remoteError != null )
            {
                return BadRequest("Error");
            }

            var info = await _auth.GetExternalLoginInfoAsync();

            if ( info == null )
            {
                return BadRequest("Error loading external login");
            }

            var result = await _auth.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false);

            if ( result.Succeeded)
            {
                return Ok("Success!!!");
            }
            return BadRequest("Login unsuccessful");
        }
    }
}
