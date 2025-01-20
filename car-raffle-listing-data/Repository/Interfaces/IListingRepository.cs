
using car_raffle_listing_data.EF_Models;

namespace car_raffle_listing_data.Repository.Interfaces;

public interface IListingRepository
{
    Task<List<Listing>> GetAllListingsAsync();
}