using car_raffle_model.Endpoint_Response;
using car_raffle_services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace car_raffle.Controllers;

[HttpResultToActionResultFilter]
public class TicketController : Controller
{
    private readonly ITicketService _service;

    public TicketController(ITicketService service)
    {
        _service = service;
    }
    
    [HttpPost]
    [Route("/api/v1/tickets")]
    public async Task<HttpResult<bool>> AddTicketAsync(Guid listingId, Guid userId)
    {
        return await _service.AddTicketAsync(listingId, userId);
    }
}