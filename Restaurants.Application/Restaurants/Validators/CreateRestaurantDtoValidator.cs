using FluentValidation;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Validators;
public class CreateRestaurantDtoValidator 
    : AbstractValidator<CreateRestaurantDto>
{
    private readonly List<string> validCategory =
        ["Italian", "Mexican" , "Japanese" , "Indian" , "American"];
    public CreateRestaurantDtoValidator()
    {
        RuleFor(dto => dto.Category)
            .Must(category => validCategory.Contains(category))
            .WithMessage("Invalid Category, please choose from the valid categories.");
            //.Custom((value , context) =>
            //{
            //    var isValidCategory = validCategory.Contains(value);
            //    if (!isValidCategory)
            //    {
            //        context.AddFailure("Category" , "Invalid Category, please choose from the valid categories.");
            //    }
            //});

        RuleFor(dto => dto.Name)
            .Length(3 , 100);

        RuleFor(dto => dto.Description)
            .NotEmpty()
            .WithMessage("Description is required");

        RuleFor(dto => dto.Category)
            .NotEmpty()
            .WithMessage("Insert a valid category");

        RuleFor(dto => dto.ContactEmail)
            .EmailAddress()
            .WithMessage("Please provide a valid email address");

        RuleFor(dto => dto.PostalCode)
            .Matches(@"^\d{2}-\d{3}$")
            .WithMessage("please provide a valid postal code (XX-XXX).");

    }
}
