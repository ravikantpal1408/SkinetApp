using Dapper;
using SkynetApp.API.Data;
using SkynetApp.API.Models;
using SkynetApp.API.Services;
using System.Data;

namespace SkynetApp.API.Repository
{
    public class AccountRepository : IAccountService
    {
        private readonly SkynetDbContext _context;
        public AccountRepository(SkynetDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AppUser>> RegisterAsync(AppUser appUser, string password)
        {
            byte[] passwordHash, passwordSalt;
            using var connection = _context.CreateConnection();
            var checkUserExists = await connection.QueryAsync<AppUser>("SELECT * FROM tblAppUser WHERE Username = @Username",
                new { Username = appUser.Username });
            if (checkUserExists.Count() > 0)
            {
                return null;
            }

            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var result = await connection.QueryAsync<AppUser>("spRegisterUser",
                new 
                { 
                    Id = appUser.Id, 
                    Username = appUser.Username, 
                    PasswordHash = passwordHash, 
                    PasswordSalt = passwordSalt
                }
                , commandType: CommandType.StoredProcedure);

            return result;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));            
        }


    }
}
