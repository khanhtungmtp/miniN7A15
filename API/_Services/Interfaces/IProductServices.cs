using API.Models;

namespace API._Services.Interfaces
{
    public interface IProductServices
    {
        List<Product> GetAllProducts();
        Task<bool> AddProduct();
        Task<bool> Update();
        Task<Product> GetProductById(string id);
    }
}