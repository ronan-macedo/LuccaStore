using LuccaStore.Core.Application.Exceptions;
using LuccaStore.Core.Domain;
using LuccaStore.Core.Domain.Entities;
using LuccaStore.Core.Domain.Interfaces;
using LuccaStore.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LuccaStore.Infrastructure.Data.Repository
{
    public class CategoryRepository : BaseRepository<CategoryEntity>, ICategoryRepository
    {
        private readonly DbSet<CategoryEntity> _dbSet;

        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _dbSet = context.Set<CategoryEntity>();
        }

        public async Task<CategoryEntity> GetByCategoryNameAsync(string categoryName)
        {
            var entity = await _dbSet.SingleOrDefaultAsync(c => c.CategoryName.Contains(categoryName));

            if (entity == null)
            {
                throw new NotFoundException(MessageTemplate.EntityNotFoundMessage,
                                            MessageTemplate.EntityNotFoundError);
            }

            return entity;
        }
    }
}
