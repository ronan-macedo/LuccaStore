using LuccaStore.Core.Domain.Entities;

namespace LuccaStore.Core.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<bool> DeleteAsync(Guid id);
        Task<bool> ExistAsync(Guid id);
        Task<IEnumerable<T>?> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task<T?> InsertAsync(T entity);
        Task<T?> UpdateAsync(T entity);
    }
}
