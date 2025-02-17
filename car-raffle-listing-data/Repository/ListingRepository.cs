using car_raffle_listing_data.Context;
using car_raffle_listing_data.EF_Models;
using car_raffle_listing_data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace car_raffle_listing_data.Repository;

public class ListingRepository : IListingRepository
{
    private readonly ListingContext _context;

    public ListingRepository(ListingContext context)
    {
        _context = context;
    }

    public async Task<List<Listing>> GetAllListingsAsync()
    {
        return await _context.Listings
            .ToListAsync();
    }
}