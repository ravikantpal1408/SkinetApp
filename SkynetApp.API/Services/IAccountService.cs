using SkynetApp.API.Models;

namespace SkynetApp.API.Services
{
    public interface IAccountService
    {
        public Task<IEnumerable<AppUser>> RegisterAsync(AppUser appUser, string password);

    }
}
