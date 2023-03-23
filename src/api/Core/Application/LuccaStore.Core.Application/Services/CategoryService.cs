using AutoMapper;
using LuccaStore.Core.Application.Exceptions;
using LuccaStore.Core.Application.Interfaces;
using LuccaStore.Core.Domain;
using LuccaStore.Core.Domain.Dtos.Categories;
using LuccaStore.Core.Domain.Entities;
using LuccaStore.Core.Domain.Interfaces;
using LuccaStore.Core.Domain.Models.Categories;

namespace LuccaStore.Core.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryResponseDto> CreateCategoryAsync(CategoryRequestDto request)
        {
            var model = _mapper.Map<CategoryModel>(request);

            model.Id = Guid.NewGuid();
            model.CreateAt = DateTime.UtcNow;

            var entity = _mapper.Map<CategoryEntity>(model);
            var result = await _categoryRepository.InsertAsync(entity);

            return _mapper.Map<CategoryResponseDto>(result);
        }

        public async Task<CategoryResponseDto> DeleteCategoryAsync(Guid categoryId)
        {
            var result = await _categoryRepository.DeleteAsync(categoryId);

            if (!result)
            {
                throw new InvalidParametersException(MessageTemplate.DeleteError,
                                                     MessageTemplate.DeleteErrorMessage);
            }

            return new CategoryResponseDto { Id = categoryId };
        }

        public async Task<IEnumerable<CategoryResponseDto>> GetAllCategoriesAsync()
        {
            var result = await _categoryRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<CategoryResponseDto>>(result);
        }

        public async Task<CategoryResponseDto> GetCategoryByIdAsync(Guid categoryId)
        {
            var result = await _categoryRepository.GetByIdAsync(categoryId);

            return _mapper.Map<CategoryResponseDto>(result);
        }

        public async Task<CategoryResponseDto> GetCategoryByNameAsync(CategoryRequestDto request)
        {
            var result = await _categoryRepository.GetByCategoryNameAsync(request.CategoryName);

            return _mapper.Map<CategoryResponseDto>(result);
        }

        public async Task<CategoryResponseDto> UpdateCategoryAsync(CategoryRequestDto request, Guid categoryId)
        {
            var entity = await _categoryRepository.GetByIdAsync(categoryId);

            entity!.CategoryName = request.CategoryName;
            entity.UpdateAt = DateTime.UtcNow;

            var result = await _categoryRepository.UpdateAsync(entity);

            return _mapper.Map<CategoryResponseDto>(result);
        }
    }
}
