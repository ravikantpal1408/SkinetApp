using Microsoft.AspNetCore.Mvc;
using SkynetApp.API.Dtos;
using SkynetApp.API.Models;
using SkynetApp.API.Services;

namespace SkynetApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
  

        [Microsoft.AspNetCore.Mvc.HttpPost("register")]
        public async Task<IActionResult> Register(UserDto user)
        {
            var newUser = new AppUser()
            {
                Id = Convert.ToString(new Guid()),
                Username = user.Username,
            };
            var response = await _accountService.RegisterAsync(newUser, user.Password);

            return Ok(response);
        }
    }
}
