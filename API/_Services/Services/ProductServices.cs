using API._Repositories;
using API._Services.Interfaces;
using API.Dtos;
using API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API._Services.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IRepositoryAccessor _repo;
        private readonly IMapper _mapper;

        public ProductServices(IRepositoryAccessor repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<bool> AddProduct(ProductCreateDto model)
        {
            try
            {
                var modelMapper = _mapper.Map<Product>(model);
                await _repo.Product.AddAsync(modelMapper);
                return await _repo.Product.SaveAsync();
            }
            catch (System.Exception err)
            {
                System.Console.WriteLine(err);
                throw;
            }

        }

        public async Task<List<ProductListDto>> GetAllProducts()
        {
            List<Product> data = await _repo.Product.FindAll().ToListAsync();
            return _mapper.Map<List<ProductListDto>>(data);
        }

        public async Task<Product> GetProductById(string id)
        {
            return await _repo.Product.FindById(id);
        }

        public async Task<bool> Update()
        {
            var product = await _repo.Product.FindById("8387028A-7353-4548-ADF2-40E559A45721");
            product.Name = "Tung";
            _repo.Product.Update(product);
            return await _repo.Product.SaveAsync();
        }
    }
}