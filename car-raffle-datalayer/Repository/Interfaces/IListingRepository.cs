using car_raffle_model;

namespace car_raffle_datalayer.Repository.Interfaces;

public interface IListingRepository
{
    Task<List<Listing>> GetAllListingsAsync();
    Task<List<Listing>> GetAllActiveListingsAsync();
    Task<Listing?> GetListingById(Guid listingId);
    Task<int> CreateListingAsync(Listing listing);
    Task<int> ReviewListingAsync(Listing listing, bool isApproved);
}