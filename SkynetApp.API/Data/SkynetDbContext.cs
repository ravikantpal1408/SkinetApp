using System.Data;
using System.Data.SqlClient;

namespace SkynetApp.API.Data;

public class SkynetDbContext
{
    private readonly string _connectionString;
    
    public SkynetDbContext(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnectionPC");
    }

    public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
}