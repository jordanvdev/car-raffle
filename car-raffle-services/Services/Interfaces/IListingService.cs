using car_raffle_model;
using car_raffle_model.API_Models;

namespace car_raffle_services.Interfaces;

public interface IListingService
{
    Task<List<Listing>> GetAllListingsAsync();
    Task<bool> CreateListing(ListingRequest listingRequest);
}