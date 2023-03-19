using API._Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _services;

        public ProductController(IProductServices services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult GetAllProduct() => Ok(_services.GetAllProducts());
        [HttpPost]
        public async Task<IActionResult> AddProducts() => Ok(await _services.AddProduct());
    }
}