using FluentValidation;

namespace Restaurants.Application.Dishes.Commands.CreateDish;
public class CreateDishCommandValidator
    : AbstractValidator<CreateDishCommand>
{
    public CreateDishCommandValidator()
    {
        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("price must be non-negative number");

        RuleFor(x => x.KiloCalories)
            .GreaterThanOrEqualTo(0)
            .WithMessage("KiloCalories must be non-negative number");
    }
}
