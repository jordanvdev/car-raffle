using car_raffle_listing_data.Model;
using car_raffle_listing_data.Repository.Interfaces;
using car_raffle_listings_services.Services.Interfaces;
using car_raffle_model.Endpoint_Response;
using FluentValidation;

namespace car_raffle_services.Services;

public class ListingService : IListingService
{
    private readonly IListingRepository _listingRepository;
    private readonly IValidator<ListingRequest> _validator;

    public ListingService(IListingRepository listingRepository, IValidator<ListingRequest> validator)
    {
        _listingRepository = listingRepository;
        _validator = validator;
    }

    public async Task<HttpResult<List<ListingResponse>>> GetAllListingsAsync()
    {
        var result = await _listingRepository.GetAllListingsAsync();
        var responses = result.Select(a => new ListingResponse(a)).ToList();
        return HttpResult<List<ListingResponse>>.Ok(responses);
    }
}