using API._Repositories.Interfaces;
using API._Repositories.Repositories;
using API.Data;

namespace API._Repositories
{
    public class RepositoryAccessor : IRepositoryAccessor
    {
        private readonly MyDbContext _context;

        public RepositoryAccessor(MyDbContext context)
        {
            _context = context;
            Product = new ProductRepository(_context);
        }

        public IProductRepository Product { get; }
    }
}