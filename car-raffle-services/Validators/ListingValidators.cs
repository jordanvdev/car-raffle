using car_raffle_model;
using car_raffle_model.API_Models;
using FluentValidation;

namespace car_raffle_services.Validators;

public class ListingRequestValidator : AbstractValidator<ListingRequest>
{
    public ListingRequestValidator()
    {
        RuleFor(listing => listing.UserId).NotNull();
        RuleFor(listing => listing.Make).NotEmpty();
        RuleFor(listing => listing.Model).NotEmpty();
        RuleFor(listing => listing.Color).NotEmpty();
        RuleFor(listing => listing.CreatedAt.Year).InclusiveBetween(2024,DateTime.Now.Year);
        RuleFor(listing => listing.Year).InclusiveBetween(1980, DateTime.Now.Year);
    }
    
}