using System.Linq.Expressions;
using API.Models.common;

namespace API._Repositories
{
    public interface IRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        // read
        IQueryable<T> FindAll(bool tracking = true);
        IQueryable<T> FindAll(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> FindSingleAsync(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> FindById(string id, bool tracking = true);
        // write
        Task<bool> AddAsync(T model);
        Task<bool> AddMultiple(List<T> datas);
        bool Remove(T model);
        bool RemoveMultiple(List<T> datas);
        Task<bool> RemoveAsync(string id);
        bool Update(T model);
        Task<bool> SaveAsync();
    }
}