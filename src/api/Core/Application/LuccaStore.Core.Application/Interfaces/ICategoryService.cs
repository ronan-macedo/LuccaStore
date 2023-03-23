using LuccaStore.Core.Domain.Dtos.Categories;

namespace LuccaStore.Core.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryResponseDto> CreateCategoryAsync(CategoryRequestDto request);
        Task<CategoryResponseDto> DeleteCategoryAsync(Guid categoryId);
        Task<IEnumerable<CategoryResponseDto>> GetAllCategoriesAsync();
        Task<CategoryResponseDto> GetCategoryByIdAsync(Guid categoryId);
        Task<CategoryResponseDto> GetCategoryByNameAsync(CategoryRequestDto request);
        Task<CategoryResponseDto> UpdateCategoryAsync(CategoryRequestDto request, Guid categoryId);        
    }
}
