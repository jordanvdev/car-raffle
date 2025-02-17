using car_raffle_ticket_data.EF_Models;

namespace car_raffle_ticket_data.Repository;

public interface ITicketRepository
{
    Task<bool> AddTicketAsync(Ticket ticket);
    Task<List<Ticket>> GetAllTicketsByListingIdAsync(Guid listingId);
}