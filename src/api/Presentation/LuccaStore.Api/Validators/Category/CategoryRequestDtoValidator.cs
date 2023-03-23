using FluentValidation;
using LuccaStore.Core.Domain.Dtos.Categories;

namespace LuccaStore.Api.Validators.Category
{
    public class CategoryRequestDtoValidator : AbstractValidator<CategoryRequestDto>
    {
        public CategoryRequestDtoValidator()
        {
            RuleFor(_ => _.CategoryName)
                .NotEmpty();
        }
    }
}
