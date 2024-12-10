using FluentValidation;
using Api.Models;

namespace Api.Validators;

public class UpdateTripValidator : AbstractValidator<UpdateTripRequest>
{
    public UpdateTripValidator()
    {
       When(trip => trip.StartDate.HasValue || trip.EndDate.HasValue, () => {
            RuleFor(trip => trip.StartDate)
                .NotNull()
                .WithMessage("Start date and End Date must be provided when updating dates");
            
            RuleFor(trip => trip.EndDate)
                .NotNull()
                .WithMessage("Start date and End Date must be provided when updating dates")
                .GreaterThan(trip => trip.StartDate!.Value)
                .When(trip => trip.StartDate.HasValue)
                .WithMessage("End date must be after start date");
        });
    }
}
