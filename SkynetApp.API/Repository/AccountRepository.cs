using Dapper;
using SkynetApp.API.Data;
using SkynetApp.API.Dtos;
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
                    UserId = appUser.UserId,
                    Username = appUser.Username, 
                    PasswordHash = passwordHash, 
                    PasswordSalt = passwordSalt
                } , commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<AppUserDto> LoginAsync(string username, string password)
        {
            using var connection = _context.CreateConnection();
            var userRow = await connection.QueryAsync<AppUser>
                ($"SELECT * FROM tblAppUser WHERE Username = @Username AND IsActive=1",
                new { Username  = username });
            if(!userRow.Any())
            {
                return null;
            }

            var user = userRow.FirstOrDefault();
            var response = new AppUserDto
            {
                Id = user.Id,
                UserId = user.UserId,
                Username = user.Username,
                CreadedBy = user.CreadedBy,
                CreatedDate = user.CreatedDate,
                UpdatedBy = user.UpdatedBy,
                UpdatedDate = user.UpdatedDate,
                IsActive = user.IsActive,
                
            };

            return VerifyPassword(password, user.PasswordHash, user.PasswordSalt) ? response : null;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));            
        }

        private static bool VerifyPassword(string password, byte[] passordHash, byte[] passowrdSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512(passowrdSalt);
            var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            for(int i = 0; i < computeHash.Length; i++)
            {
                if(computeHash[i] != passordHash[i])
                {
                    return false;
                }
            }
            return true;
        }


    }
}
