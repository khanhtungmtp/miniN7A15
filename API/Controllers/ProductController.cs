using API._Services.Interfaces;
using API.Dtos;
using API.Models;
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

        [HttpGet("GetAllProduct")]
        public IActionResult GetAllProduct() => Ok(_services.GetAllProducts());
        [HttpGet("GetProductById")]
        public async Task<IActionResult> GetProductById(string id) => Ok(await _services.GetProductById(id));
        [HttpPost]
        public async Task<IActionResult> AddProducts(ProductDto model) => Ok(await _services.AddProduct(model));
        [HttpPut]
        public async Task<IActionResult> UpdateProduct() => Ok(await _services.Update());

    }
}