using FluentValidation;

namespace LuccaStore.Api.Validators.Identity
{
    public class UsernameValidator : AbstractValidator<string>
    {
        public UsernameValidator()
        {
            RuleFor(_ => _)
                .NotEmpty();
        }
    }
}
