using car_raffle_listing_data.Model;
using car_raffle_model.Endpoint_Response;

namespace car_raffle_listings_services.Services.Interfaces;

public interface IListingService
{
    Task<HttpResult<List<ListingResponse>>> GetAllListingsAsync();
    Task<HttpResult<ListingResponse>> GetListingByIdAsync(Guid listingId);
}