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
    public async Task<IActionResult> GetAllProduct()
    {
        var res = await _product.GetAllProducts();
        //throw new Exception("custom error happening here");
        return Ok(res);
    }

    [HttpGet("product")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var res = await _product.GetProduct(id);
        return Ok(res);
    }
    
}