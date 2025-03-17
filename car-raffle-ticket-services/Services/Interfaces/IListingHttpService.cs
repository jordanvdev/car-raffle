using car_raffle_ticket_data.Models;

namespace car_raffle_ticket_services.Services.Interfaces;

public interface IListingHttpService
{
    Task<ListingResponse?> GetListingByIdAsync(Guid listingId);
}