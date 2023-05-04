using API._Services.Interfaces;
using API.Dtos;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _services;
        private readonly IValidator<ProductCreateDto> _validator;

        public ProductController(IProductServices services, IValidator<ProductCreateDto> validator)
        {
            _services = services;
            _validator = validator;
        }

        [HttpGet("GetAllProduct")]
        public async Task<IActionResult> GetAllProduct() => Ok(await _services.GetAllProducts());
        [HttpGet("GetProductById")]
        public async Task<IActionResult> GetProductById(string id) => Ok(await _services.GetProductById(id));
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> AddProducts(ProductCreateDto model)
        {
            ValidationResult result = await _validator.ValidateAsync(model);

            if (!result.IsValid)
            {
                // Copy the validation results into ModelState.
                // ASP.NET uses the ModelState collection to populate 
                // error messages in the View.
                result.AddToModelState(this.ModelState);
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            return Ok(await _services.AddProduct(model));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct() => Ok(await _services.Update());

    }
}