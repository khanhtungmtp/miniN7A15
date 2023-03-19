using System.Linq.Expressions;
using API.Data;
using API.Models.common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace API._Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly MyDbContext _context;

        public Repository(MyDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        // Write

        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entry = await Table.AddAsync(model);
            return entry.State == EntityState.Added;
        }

        public async Task<bool> AddMultiple(List<T> datas)
        {
            await Table.AddRangeAsync(datas);
            return true;
        }

        public bool Remove(T model)
        {
            EntityEntry<T> entry = Table.Remove(model);
            return entry.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            T? model = await Table.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
            if (model != null)
                return Remove(model);
            return false;
        }

        public bool RemoveMultiple(List<T> datas)
        {
            Table.RemoveRange(datas);
            return true;
        }

        public async Task<bool> SaveAsync() => await _context.SaveChangesAsync() > 0;

        public bool Update(T model)
        {
            EntityEntry<T> entry = Table.Update(model);
            return entry.State == EntityState.Modified;
        }

        // Read

        public IQueryable<T> FindAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public async Task<T> FindById(string id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return (await query.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id)))!;
        }

        public async Task<T> FindSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return (await query.FirstOrDefaultAsync(method))!;
        }

    }
}