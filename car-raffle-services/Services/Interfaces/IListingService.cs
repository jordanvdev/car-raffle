using car_raffle_model;

namespace car_raffle_services.Interfaces;

public interface IListingService
{
    Task<List<Listing>> GetAllListings();
}