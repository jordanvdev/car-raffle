using car_raffle_model;
using Microsoft.EntityFrameworkCore;
using Tarkov_Info_DataLayer.Repository.Interfaces;

namespace Tarkov_Info_DataLayer.Repository;

public class ListingRepository : IListingRepository
{
    private readonly RaffleContext _context;

    public ListingRepository(RaffleContext context)
    {
        _context = context;
    }

    public async Task<List<Listing>> GetAllListingsAsync()
    {
        return await _context.Listings.ToListAsync();
    }
    
    public async Task<int> CreateListingAsync(Listing listing)
    {
        await _context.Listings.AddAsync(listing);
        return await _context.SaveChangesAsync();
    }
}