using car_raffle_model;
using car_raffle_model.API_Models;
using car_raffle_services.Interfaces;
using Tarkov_Info_DataLayer.Repository.Interfaces;

namespace car_raffle_services.Services;

public class ListingService : IListingService
{
    private readonly IListingRepository _listingRepository;
    private readonly IUserRepository _userRepository;

    public ListingService(IListingRepository listingRepository, IUserRepository userRepository)
    {
        _listingRepository = listingRepository;
        _userRepository = userRepository;
    }

    public async Task<List<Listing>> GetAllListingsAsync()
    {
        return await _listingRepository.GetAllListingsAsync();
    }

    public async Task<bool> CreateListing(ListingRequest listingRequest)
    {
        var user = await _userRepository.GetUserByIdAsync(listingRequest.UserId);
        if (user == null)
            return false;

        var car = new Car(listingRequest);
        var listing = new Listing(car,user,listingRequest);
        
        await CalculateListingTicketDetails(listingRequest,listing);
        
        var result = await _listingRepository.CreateListingAsync(listing);

        return result > 1;
    }
    
    //TODO Make this a bit smarter
    private async Task CalculateListingTicketDetails(ListingRequest listingRequest, Listing listing)
    {
        var price = listingRequest.Price;
        var ticketPrice = listingRequest.TicketPrice;
        var maxTickets = (int)Math.Ceiling(price / ticketPrice);
        
        listing.MaxTicketCount = maxTickets;
        listing.CurrentTicketCount = 0;
        listing.TicketPrice = ticketPrice;
    }
}