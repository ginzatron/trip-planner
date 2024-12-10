using FluentValidation;
using Api.Models;

namespace Api.Validators;

public class CreateTripValidator : AbstractValidator<CreateTripRequest>
{
    public CreateTripValidator()
    {
        RuleFor(trip => trip.StartDate)
            .LessThan(trip => trip.EndDate)
            .WithMessage("Start date must be before end date");
    }
}
