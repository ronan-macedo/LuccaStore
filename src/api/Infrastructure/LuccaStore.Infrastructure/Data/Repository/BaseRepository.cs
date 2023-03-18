using LuccaStore.Core.Domain.Entities;
using LuccaStore.Core.Domain.Interfaces;
using LuccaStore.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LuccaStore.Infrastructure.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                T? result = await _dbSet.SingleOrDefaultAsync(e => e.Id == id);

                if (result == null)
                {
                    return false;
                }

                _dbSet.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> ExistAsync(Guid id)
        {
            return await _dbSet.AnyAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<T>?> GetAllAsync()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            try
            {
                return await _dbSet.SingleOrDefaultAsync(e => e.Id == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<T?> InsertAsync(T entity)
        {
            try
            {
                _dbSet.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return null;
            }

            return entity;
        }

        public async Task<T?> UpdateAsync(T entity)
        {
            try
            {
                T? result = await _dbSet.SingleOrDefaultAsync(t => t.Id == entity.Id);

                if (result == null)
                {
                    return null;
                }

                _context.Entry(result).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return null;
            }

            return entity;
        }
    }
}
