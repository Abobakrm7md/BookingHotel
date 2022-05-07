using BookingHotel.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingHotel.DAL.Repository.Base
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> Table { get; }
        IQueryable<T> TableNoTracking { get; }
        Task<T> GetByIdAsync(string id);
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        Task<T> SaveAsync(T entity, bool IsNew);
        Task DeleteAsync(T entity);
        Task<int> DeleteRangeAsync(IEnumerable<T> entities); 
        Task<int> UpdateRange(IEnumerable<T> entities);
    }
}