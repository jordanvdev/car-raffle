using car_raffle_model.Endpoint_Response;
using car_raffle_ticket_data.Response_Models;

namespace car_raffle_ticket_services.Services.Interfaces;

public interface ITicketService
{
    Task<HttpResult<bool>> AddTicketAsync(Guid listingId, Guid userId);
    Task<HttpResult<List<TicketResponse>>> GetTicketsByListingIdAsync(Guid listingId);
}