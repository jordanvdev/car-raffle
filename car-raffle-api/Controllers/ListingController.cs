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
    public async Task<IActionResult> GetAllListings()
    {
        var listings = await _service.GetAllListings();
        return Ok(listings);
    }
    
}