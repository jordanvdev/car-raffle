using car_raffle_datalayer.Repository.Interfaces;
using car_raffle_model;
using car_raffle_model.API_Models;
using car_raffle_model.Endpoint_Response;
using car_raffle_services.Services.Interfaces;
using FluentValidation;
using Tarkov_Info_DataLayer.Repository.Interfaces;

namespace car_raffle_services.Services;

public class ListingService : IListingService
{
    private readonly IListingRepository _listingRepository;
    private readonly IUserRepository _userRepository;
    private readonly IValidator<ListingRequest> _validator;

    public ListingService(IListingRepository listingRepository, IUserRepository userRepository, IValidator<ListingRequest> validator)
    {
        _listingRepository = listingRepository;
        _userRepository = userRepository;
        _validator = validator;
    }

    public async Task<HttpResult<List<ListingResponse>>> GetAllListingsAsync()
    {
        var result = await _listingRepository.GetAllListingsAsync();
        var responses = result.Select(a => new ListingResponse(a)).ToList();
        return HttpResult<List<ListingResponse>>.Ok(responses);
    }
    
    public async Task<HttpResult<List<ListingResponse>>> GetAllActiveListingsAsync()
    {
        var result = await _listingRepository.GetAllActiveListingsAsync();
        var responses = result.Select(a => new ListingResponse(a)).ToList();
        return HttpResult<List<ListingResponse>>.Ok(responses);
    }

    public async Task<HttpResult<bool>> CreateListingAsync(ListingRequest listingRequest)
    {
        var validationResult = await _validator.ValidateAsync(listingRequest);
        if(!validationResult.IsValid)
            return HttpResult<bool>.BadRequest(string.Concat(validationResult.Errors.Select(x => x.ErrorMessage).ToList()));
        
        var user = await _userRepository.GetUserByIdAsync(listingRequest.UserId);
        if (user == null)
            return HttpResult<bool>.Forbidden($"User {listingRequest.UserId} not found");

        var car = new Car(listingRequest);
        var listing = new Listing(car,user,listingRequest);
        
        CalculateListingTicketDetails(listingRequest,listing);
        
        await _listingRepository.CreateListingAsync(listing);

        return HttpResult<bool>.Ok(true);
    }

    public async Task<HttpResult<bool>> ReviewListingAsync(Guid listingId, bool isApproved)
    {
        var listing = await _listingRepository.GetListingById(listingId);
        
        if(listing == null)
            return HttpResult<bool>.BadRequest($"Listing {listingId} not found");
        
        await _listingRepository.ReviewListingAsync(listing, isApproved);
        
        return HttpResult<bool>.Ok(true);
    }
    
    public async Task<HttpResult<bool>> DeleteListingAsync(Guid listingId)
    {
        var listing = await _listingRepository.GetListingById(listingId);
        
        if(listing == null)
            return HttpResult<bool>.BadRequest($"Listing {listingId} not found");

        await _listingRepository.DeleteListingAsync(listing);
        
        return HttpResult<bool>.Ok(true);
    }

    //TODO Make this a bit smarter
    private void CalculateListingTicketDetails(ListingRequest listingRequest, Listing listing)
    {
        var price = listingRequest.Price;
        var ticketPrice = listingRequest.TicketPrice;
        var maxTickets = (int)Math.Ceiling(price / ticketPrice);
        
        listing.MaxTicketCount = maxTickets;
        listing.CurrentTicketCount = 0;
        listing.TicketPrice = ticketPrice;
    }
}