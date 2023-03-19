using API.Models;

namespace API._Services.Interfaces
{
    public interface IProductServices
    {
        List<Product> GetAllProducts();
        Task<bool> AddProduct();
    }
}