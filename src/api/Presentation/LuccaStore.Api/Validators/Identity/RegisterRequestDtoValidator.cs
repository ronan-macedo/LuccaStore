using FluentValidation;
using LuccaStore.Core.Domain.Dtos.Identity;

namespace LuccaStore.Api.Validators.Identity
{
    public class RegisterRequestDtoValidator : AbstractValidator<RegisterRequestDto>
    {
        public RegisterRequestDtoValidator()
        {
            RuleFor(_ => _.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(_ => _.Password)
                .NotEmpty()
                .MinimumLength(6);

            RuleFor(_ => _.Username)
                .NotEmpty();
        }
    }
}
