using car_raffle_ticket_data.Context;
using car_raffle_ticket_data.EF_Models;
using Microsoft.EntityFrameworkCore;

namespace car_raffle_ticket_data.Repository;

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

    public Task<List<Ticket>> GetAllTicketsByListingIdAsync(Guid listingId)
    {
        return _context.Tickets.Where(a => a.ListingId == listingId).ToListAsync();
    }
}