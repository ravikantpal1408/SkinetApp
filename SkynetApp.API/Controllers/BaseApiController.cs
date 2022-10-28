using Microsoft.AspNetCore.Mvc;
using SkynetApp.API.Dtos;
using SkynetApp.API.Models;
using SkynetApp.API.Services;

namespace SkynetApp.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        public BaseApiController()
        {

        }
    }
}
