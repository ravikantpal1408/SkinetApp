using Microsoft.AspNetCore.Identity;

namespace SkynetApp.API.Entities
{
    public class User : IdentityUser<int>
    {
        public UserAddress Address { get; set; }
    }
}
