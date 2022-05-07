using BookingHotel.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BookingHotel.DAL.Repository.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
        {
            public RepositoryBase(BookingHotelContext context)
            {
                _context = context;
            }

            //private readonly DbContext _context;
            protected readonly BookingHotelContext _context;

            private DbSet<T> _entities;

            protected virtual DbSet<T> Entities
            {
                get
                {
                    if (_entities == null)
                        _entities = _context.Set<T>();

                    return _entities;
                }
            }
           
            public async virtual Task<T> GetByIdAsync(int id)
            {
                return await Entities.FindAsync(id);
            }
           
            public async virtual Task<T> GetByIdAsync(string id)
            {
                return await Entities.FindAsync(id);
            }
            public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
            {
                Entities.AddRange(entities);
                await _context.SaveChangesAsync();

                return entities;
            }
            public async Task<T> SaveAsync(T entity, bool IsNew)
            {
                if (IsNew)
                {
                    Entities.Add(entity);
                }
                else
                {
                    _context.Entry(entity).State = EntityState.Modified;
                }

                await _context.SaveChangesAsync();

                return entity;
            }
            public async Task DeleteAsync(T entity)
            {
                Entities.Remove(entity);
                await _context.SaveChangesAsync();
            }


            public async Task<int> DeleteRangeAsync(IEnumerable<T> entities) // (hamed.h 15-Apr 2020)
            {
                Entities.RemoveRange(entities);
                return await _context.SaveChangesAsync();
            }

            public async virtual Task<IReadOnlyList<T>> ListAllAsync()
            {
                return await Entities.ToListAsync();
            }

            public IQueryable<T> Table => Entities;

            public IQueryable<T> TableNoTracking => Entities.AsNoTracking();
        public async Task<int> UpdateRange(IEnumerable<T> entities)
            {
                Entities.UpdateRange(entities);
                return await _context.SaveChangesAsync();

            }

    }
}
