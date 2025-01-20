using car_raffle_model;
using Microsoft.EntityFrameworkCore;
using Tarkov_Info_DataLayer.Repository.Interfaces;

namespace Tarkov_Info_DataLayer.Repository;

public class TicketRepository : ITicketRepository
{
    private readonly RaffleContext _context;

    public TicketRepository(RaffleContext context)
    {
        _context = context;
    }

    public async Task<bool> AddTicketAsync(Ticket ticket)
    {
        await _context.Tickets.AddAsync(ticket);
        return await _context.SaveChangesAsync() > 0;
    }
}