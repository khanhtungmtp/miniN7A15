using API.Dtos;
using API.Models;

namespace API._Services.Interfaces
{
    public interface IProductServices
    {
        List<Product> GetAllProducts();
        Task<bool> AddProduct(ProductDto model);
        Task<bool> Update();
        Task<Product> GetProductById(string id);
    }
}