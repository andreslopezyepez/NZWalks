using FluentValidation;
using NZWalks.Api.Models.Dto;

namespace NZWalks.Api.Validators
{
    public class AddRegionRequestValidator : AbstractValidator<AddRegionRequest>
    {
        public AddRegionRequestValidator()
        {
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Population).GreaterThanOrEqualTo(0);
        }
    }
}
