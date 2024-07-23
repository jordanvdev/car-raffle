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

    public async Task<List<Listing>> GetAllListings()
    {
        return await _context.Listings.ToListAsync();
    }
}