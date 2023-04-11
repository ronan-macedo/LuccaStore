using LuccaStore.Core.Domain.Entities;

namespace LuccaStore.Core.Domain.Interfaces
{
    public interface ICategoryRepository : IRepository<CategoryEntity>
    {
        Task<CategoryEntity> GetByCategoryNameAsync(string categoryName);
        Task<bool> CategoryNameExistsAsync(string categoryName);
    }
}
