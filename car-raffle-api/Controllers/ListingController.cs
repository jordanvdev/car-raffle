using car_raffle_model;
using car_raffle_model.API_Models;
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
    public async Task<IActionResult> GetAllListingsAsync()
    {
        var listings = await _service.GetAllListingsAsync();
        return Ok(listings);
    }

    [HttpPost]
    [Route("/api/v1/listings")]
    public async Task<IActionResult> CreateListingAsync([FromBody] ListingRequest listing)
    {
        var result = await _service.CreateListing(listing);

        if (!result)
            return BadRequest(result);
        
        return Ok(result);
    }
}