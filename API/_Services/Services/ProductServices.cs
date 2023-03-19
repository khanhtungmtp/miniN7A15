using API._Repositories;
using API._Services.Interfaces;
using API.Models;

namespace API._Services.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IRepositoryAccessor _repo;

        public ProductServices(IRepositoryAccessor repo)
        {
            _repo = repo;
        }

        public async Task<bool> AddProduct()
        {
            try
            {
                await _repo.Product.AddMultiple(GetAllProducts());
                return await _repo.Product.SaveAsync();
            }
            catch (System.Exception err)
            {
                System.Console.WriteLine(err);
                throw;
            }

        }

        public List<Product> GetAllProducts() => new()
        {
            new() {Id=Guid.NewGuid(),Name="Product 1", Price=1500, Stock=10},
            new() {Id=Guid.NewGuid(),Name="Product 2", Price=6500, Stock=190},
            new() {Id=Guid.NewGuid(),Name="Product 3", Price=46500, Stock=199},
            new() {Id=Guid.NewGuid(),Name="Product 4", Price=46500, Stock=19},
            new() {Id=Guid.NewGuid(),Name="Product 5", Price=462500, Stock=129},
            new() {Id=Guid.NewGuid(),Name="Product 6", Price=436500, Stock=192},
        };
    }
}