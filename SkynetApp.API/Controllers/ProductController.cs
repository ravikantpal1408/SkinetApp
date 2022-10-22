using Microsoft.AspNetCore.Mvc;
using SkynetApp.API.Models;
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
    public async Task<IActionResult> GetAllProduct()
    {
        var res = await _product.GetAllProducts();
        return Ok(res);
    }
}