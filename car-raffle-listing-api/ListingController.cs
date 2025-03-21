using car_raffle_listing_data.Model;
using car_raffle_listings_services.Services.Interfaces;
using car_raffle_model.Endpoint_Response;
using Microsoft.AspNetCore.Mvc;

namespace car_raffle_listings_api;

[HttpResultToActionResultFilter]
public class ListingController
{
    private readonly IListingService _service;

    public ListingController(IListingService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("/api/v1/listings")]
    public async Task<HttpResult<List<ListingResponse>>> GetAllListingsAsync()
    {
        return await _service.GetAllListingsAsync();
    }
    
    [HttpGet]
    [Route("/api/v1/listings/{listingId}")]
    public async Task<HttpResult<ListingResponse>> GetListingByIdAsync([FromRoute] Guid listingId)
    {
        return await _service.GetListingByIdAsync(listingId);
    }
}