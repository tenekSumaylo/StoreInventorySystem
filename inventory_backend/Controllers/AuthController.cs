using FluentValidation;
using inventory_backend.Dtos;
using inventory_backend.Exceptions;
using inventory_backend.Services.AuthServices;
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
                return BadRequest(ex.ValidationResult?.Errors is null ? ex.Result!.Errors: ex.ValidationResult.Errors);
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
            catch (RegisterException ex )
            {
                return BadRequest(ex.IdentityResult.Errors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 
    }
}
