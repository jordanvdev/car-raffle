using car_raffle_model;
using car_raffle_model.API_Models;
using car_raffle_model.Endpoint_Response;
using car_raffle_services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace car_raffle.Controllers;

public class ListingController : Controller
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
    
    [HttpPost]
    [Route("/api/v1/listings")]
    public async Task<HttpResult<bool>> CreateListingAsync([FromBody] ListingRequest listing)
    {
        return await _service.CreateListingAsync(listing);
    }
    
    [HttpPut]
    [Route("/api/v1/listings/review")]
    public async Task<HttpResult<bool>> ReviewListingAsync(Guid listingId, bool isApproved)
    {
        return await _service.ReviewListingAsync(listingId, isApproved);
    }
}