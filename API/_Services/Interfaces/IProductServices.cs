using API.Dtos;
using API.Models;

namespace API._Services.Interfaces
{
    public interface IProductServices
    {
        Task<List<ProductListDto>> GetAllProducts();
        Task<bool> AddProduct(ProductCreateDto model);
        Task<bool> Update();
        Task<Product> GetProductById(string id);
    }
}