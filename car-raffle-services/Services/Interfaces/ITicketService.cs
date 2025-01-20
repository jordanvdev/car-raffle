using car_raffle_model.Endpoint_Response;

namespace car_raffle_services.Services.Interfaces;

public interface ITicketService
{
    Task<HttpResult<bool>> AddTicketAsync(Guid listingId, Guid userId);
}