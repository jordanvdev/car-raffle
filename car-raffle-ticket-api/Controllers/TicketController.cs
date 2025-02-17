using car_raffle_model.Endpoint_Response;
using car_raffle_ticket_data.Response_Models;
using car_raffle_ticket_services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace car_raffle_ticket_api.Controllers;

[HttpResultToActionResultFilter]
public class TicketController
{
    private readonly ITicketService _ticketService;

    public TicketController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }
    
    [HttpPost]
    [Route("/api/v1/tickets")]
    public async Task<HttpResult<bool>> AddTicketAsync(Guid listingId, Guid userId)
    {
        return await _ticketService.AddTicketAsync(listingId, userId);
    }
    
    [HttpGet]
    [Route("/api/v1/tickets/{listingId}")]
    public async Task<HttpResult<List<TicketResponse>>> GetTicketsByListingIdAsync(Guid listingId)
    {
        return await _ticketService.GetTicketsByListingIdAsync(listingId);
    }
}