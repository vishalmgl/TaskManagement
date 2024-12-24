using FluentValidation;
using TaskManagement.Application.Features.CityFeatures.Command;

namespace TaskManagement.Application.Features.CityFeatures
{
    public class CreateCityCommandValidator : AbstractValidator<CreateCityCommand>
    {
        public CreateCityCommandValidator()
        {
            RuleFor(x => x.Code).NotEmpty().WithMessage("City Code is required.");
            RuleFor(x => x.Title).NotEmpty().WithMessage("City Title is required.");
        }
    }
}
