using car_raffle_listing_data.EF_Models;
using car_raffle_ticket_data.Repository;

namespace Tarkov_Info_DataLayer.Repository;

public class TicketRepository : ITicketRepository
{
    private readonly TicketContext _context;

    public TicketRepository(TicketContext context)
    {
        _context = context;
    }

    public async Task<bool> AddTicketAsync(Ticket ticket)
    {
        await _context.Tickets.AddAsync(ticket);
        return await _context.SaveChangesAsync() > 0;
    }
}