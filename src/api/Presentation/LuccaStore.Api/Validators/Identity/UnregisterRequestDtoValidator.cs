using FluentValidation;
using LuccaStore.Core.Domain.Dtos.Identity;

namespace LuccaStore.Api.Validators.Identity
{
    public class UnregisterRequestDtoValidator : AbstractValidator<UnregisterRequestDto>
    {
        public UnregisterRequestDtoValidator()
        {
            RuleFor(_ => _.Username)
                .NotEmpty();
        }
    }
}
