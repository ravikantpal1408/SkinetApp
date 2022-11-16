using Microsoft.AspNetCore.Mvc;
using SkynetApp.API.Entities;
using SkynetApp.API.Services;
using System.Text.Json.Serialization;
using Newtonsoft;
using SkynetApp.API.Helper;
using AutoMapper;
using SkynetApp.API.Data;
using SkynetApp.API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace SkynetApp.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
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
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
        //var query = _context.Products
        //    .Sort(productParams.OrderBy)
        //    .Search(productParams.SearchTerm)
        //    .Filter(productParams.Brands, productParams.Types)
        //    .AsQueryable();

        //var products = await PagedList<Product>.ToPagedList(query,
        //    productParams.PageNumber, productParams.PageSize);
        var products = await _context.Products.ToListAsync();

        //Response.AddPaginationHeader(products.MetaData);

        return products;
    }

    [HttpGet("{id}", Name = "GetProduct")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null) return NotFound();

        return product;
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