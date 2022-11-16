using FluentValidation;
using NZWalks.Api.Models.Dto;

namespace NZWalks.Api.Validators
{
    public class LoginRequestValidator :AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
