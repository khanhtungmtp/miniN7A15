using API.Models.common;
using Microsoft.EntityFrameworkCore;

namespace API._Repositories
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        DbSet<T> Table { get; }
    }
}