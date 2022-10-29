using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SkynetApp.API.Dtos;
using SkynetApp.API.Models;
using SkynetApp.API.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SkynetApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IConfiguration _config;
        public AccountController(IAccountService accountService, IConfiguration config)
        {
            _accountService = accountService;
            _config = config;
        }
  

        [Microsoft.AspNetCore.Mvc.HttpPost("register")]
        public async Task<IActionResult> Register(UserDto user)
        {
            if(string.IsNullOrEmpty(user.Password) && string.IsNullOrEmpty(user.Username))
            {
                return BadRequest();
            }
            var newUser = new AppUser()
            {
                Username = user.Username,
            };
            var response = await _accountService.RegisterAsync(newUser, user.Password);

            if(response == null)
            {
                return BadRequest();
            }

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDto user)
        {
            try
            {
                if (string.IsNullOrEmpty(user.Password) && string.IsNullOrEmpty(user.Username))
                {
                    return BadRequest();
                }

                var response = await _accountService.LoginAsync(user.Username, user.Password);

                if (response == null)
                {
                    return Unauthorized("User creditials did not matched");
                }

                var token = GenerateJWT(response.Username);

                return Ok(new { 
                    token = token,
                    data = response
                });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        private string GenerateJWT(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", username) }),
                Expires = DateTime.UtcNow.AddDays(1),
                Issuer = _config["Jwt:Issuer"],
                Audience = _config["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512)

            };


            var token = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(token);

        }


    }
}
