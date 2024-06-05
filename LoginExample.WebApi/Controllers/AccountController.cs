using LoginExample.Models.DTOs;
using LoginExample.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LoginExample.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> UserManager;
        private readonly RoleManager<IdentityRole> RoleManager;
        private readonly JwtService JwtService;

        public AccountController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, JwtService jwtService)
        {
            UserManager = userManager;
            RoleManager = roleManager;
            JwtService = jwtService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<LoginResponseDTO>> Authentication([FromBody] LoginRequestDTO loginRequest)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Verifique usuario y contraseña.");
            }


            var user = await UserManager.FindByEmailAsync(loginRequest.Email);

            if (user == null)
            {
                return NotFound();
            }
            var isPasswordValid = await UserManager.CheckPasswordAsync(user, loginRequest.Password);
            if (isPasswordValid)
            {
                var token = JwtService.CreateToken(user);
                token.UserId = user.Id;
                return Ok(token);
            }
            else
            {
                return BadRequest("La contraseña es incorrecta.");
            }

        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterDTO newUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Datos incorrectos");
            }
            IdentityUser user = new()
            {
                Email = newUser.Email,
                UserName = newUser.UserName,

            };

            var result = await UserManager.CreateAsync(user, newUser.Password);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                var results = result.Errors;
                return BadRequest($"{results}");
            }
        }
    }
}
