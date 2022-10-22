using SkynetApp.API.Models;

namespace SkynetApp.API.Services;

public interface IProductService
{
    public Task<IEnumerable<Product>> GetAllProducts();
}