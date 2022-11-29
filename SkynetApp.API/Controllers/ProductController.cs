using Microsoft.AspNetCore.Mvc;
using SkynetApp.API.Entities;
using SkynetApp.API.Services;

using SkynetApp.API.Helper;
using AutoMapper;
using SkynetApp.API.Data;
using SkynetApp.API.Extensions;
using Microsoft.EntityFrameworkCore;

namespace SkynetApp.API.Controllers;


public class ProductController : BaseApiController
{
    private readonly IProductService _product;
    private readonly StoreContext _context;
    private readonly IMapper _mapper;

    public ProductController(IProductService product, StoreContext context, IMapper mapper)
    {
        _product = product;
        _mapper = mapper;
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts([FromQuery] ProductParams productParams)
    {
        var query = _context.Products
                .Sort(productParams.OrderBy)
                .Search(productParams.SearchTerm)
                .Filter(productParams.Brands, productParams.Types)
                .AsQueryable();

        var products = await PagedList<Product>.ToPagedList(query,
            productParams.PageNumber, productParams.PageSize);

        Response.AddPaginationHeader(products.MetaData);

        return products;
    }

    [HttpGet("{id}", Name = "products")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null) return NotFound();

        return product;
    }

    [HttpGet("filters")]
    public async Task<IActionResult> GetFilters()
    {
        var brands = await _context.Products.Select(p => p.Brand).Distinct().ToListAsync();
        var types = await _context.Products.Select(p => p.Type).Distinct().ToListAsync();

        return Ok(new { brands, types });
    }

    //[HttpGet("products")]
    //public async Task<IActionResult> GetAllProduct()
    //{
    //    var res = await _product.GetAllProducts();
    //    //throw new Exception("custom error happening here");
    //    //var result = JsonConverter
    //    return Ok(res);
    //}

    //[HttpGet("product")]
    //public async Task<IActionResult> GetProduct(int id)
    //{
    //    var res = await _product.GetProduct(id);
    //    return Ok(res);
    //}

    // ASSIGNMENT ( create an API to insert product into the DB )

}