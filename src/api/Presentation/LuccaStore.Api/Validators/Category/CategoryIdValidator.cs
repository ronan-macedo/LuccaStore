using FluentValidation;

namespace LuccaStore.Api.Validators.Category
{
    public class CategoryIdValidator : AbstractValidator<Guid>
    {
        public CategoryIdValidator()
        {
            RuleFor(_ => _)
                .NotNull()
                .NotEmpty()
                .NotEqual(Guid.Empty);
        }
    }
}
