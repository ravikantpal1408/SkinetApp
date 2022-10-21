using Microsoft.AspNetCore.Mvc;
using SkynetApp.API.Services;

namespace SkynetApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _product;
    
    public ProductController(IProductService product)
    {
        _product = product;
    }
    
    [HttpGet("products")]
    public string GetAllProduct()
    {
        return _product.GetAllProducts();
    }
}