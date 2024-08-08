using car_raffle_model.API_Models;
using car_raffle_model.Endpoint_Response;

namespace car_raffle_services.Interfaces;

public interface IListingService
{
    Task<HttpResult<List<ListingResponse>>> GetAllListingsAsync();
    Task<HttpResult<List<ListingResponse>>> GetAllActiveListingsAsync();
    Task<HttpResult<bool>> CreateListingAsync(ListingRequest listingRequest);
    Task<HttpResult<bool>> ReviewListingAsync(Guid listingId, bool isApproved);
}