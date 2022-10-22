using Dapper;
using SkynetApp.API.Data;
using SkynetApp.API.Models;
using SkynetApp.API.Services;

namespace SkynetApp.API.Repository;

public class ProductRepository : IProductService
{
    private readonly SkynetDbContext _context;
    public ProductRepository(SkynetDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        string sql = @"SELECT * FROM tblProduct";
        using var conn = _context.CreateConnection();
        var result = await conn.QueryAsync<Product>(sql);
        return result;
    }

    public async Task<IEnumerable<Product>> GetProduct(int id)
    {
        string sql = @"SELECT * FROM tblProduct WHERE Id = " + id.ToString();
        using var conn = _context.CreateConnection();
        var result = await conn.QueryAsync<Product>(sql);
        return result;
    }
}