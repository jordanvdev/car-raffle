using car_raffle_model;
using car_raffle_services.Interfaces;
using Tarkov_Info_DataLayer.Repository.Interfaces;

namespace car_raffle_services.Services;

public class ListingService : IListingService
{
    private readonly IListingRepository _listingRepository;

    public ListingService(IListingRepository listingRepository)
    {
        _listingRepository = listingRepository;
    }

    public Task<List<Listing>> GetAllListings()
    {
        return _listingRepository.GetAllListings();
    }
}