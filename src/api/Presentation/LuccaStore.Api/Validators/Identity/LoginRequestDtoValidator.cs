using FluentValidation;
using LuccaStore.Core.Domain.Dtos.Identity;

namespace LuccaStore.Api.Validators.Identity
{
    public class LoginRequestDtoValidator : AbstractValidator<LoginRequestDto>
    {
        public LoginRequestDtoValidator()
        {
            RuleFor(_ => _.Username)
                .NotEmpty();

            RuleFor(_ => _.Password)
                .MinimumLength(6)
                .NotEmpty();
        }
    }
}
