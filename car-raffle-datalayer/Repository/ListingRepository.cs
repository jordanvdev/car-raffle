using car_raffle_datalayer.Repository.Interfaces;
using car_raffle_model;
using Microsoft.EntityFrameworkCore;
using Tarkov_Info_DataLayer;

namespace car_raffle_datalayer.Repository;

public class ListingRepository : IListingRepository
{
    private readonly RaffleContext _context;

    public ListingRepository(RaffleContext context)
    {
        _context = context;
    }

    public async Task<List<Listing>> GetAllListingsAsync()
    {
        return await _context.Listings
            .Include(a => a.Car)
            .Include(a => a.User)
            .ToListAsync();
    }

    public async Task<List<Listing>> GetAllActiveListingsAsync()
    {
        return await _context.Listings
            .Include(a => a.Car)
            .Include(a => a.User)
            .Where(a => a.IsApproved && a.EndDate >= DateTime.Now)
            .ToListAsync();
    }

    public async Task<Listing?> GetListingById(Guid listingId)
    {
        return await _context.Listings
            .Include(a => a.Car)
            .Include(a => a.User)
            .FirstOrDefaultAsync(a => a.Id == listingId);
    }

    public async Task<int> CreateListingAsync(Listing listing)
    {
        await _context.Listings.AddAsync(listing);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> ReviewListingAsync(Listing listing, bool isApproved)
    {
        listing.IsApproved = isApproved;
        return await _context.SaveChangesAsync();
    }
    
    public async Task<int> DeleteListingAsync(Listing listing)
    {
        _context.Listings.Remove(listing!);
        return await _context.SaveChangesAsync();
    }
}