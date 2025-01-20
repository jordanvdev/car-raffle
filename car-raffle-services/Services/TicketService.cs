using car_raffle_datalayer.Repository.Interfaces;
using car_raffle_model;
using car_raffle_model.API_Models;
using car_raffle_model.Endpoint_Response;
using car_raffle_services.Services.Interfaces;
using FluentValidation;
using Tarkov_Info_DataLayer.Repository.Interfaces;

namespace car_raffle_services.Services;

public class TicketService : ITicketService
{
    private readonly IUserRepository _userRepository;
    private readonly IListingRepository _listingRepository;
    private readonly ITicketRepository _ticketRepository;
    
    public TicketService(IListingRepository listingRepository, IUserRepository userRepository, ITicketRepository ticketRepository)
    {
        _listingRepository = listingRepository;
        _userRepository = userRepository;
        _ticketRepository = ticketRepository;
    }

    public async Task<HttpResult<bool>> AddTicketAsync(Guid listingId, Guid userId)
    {
        var listing = await _listingRepository.GetListingById(listingId);
        if (listing == null)
            return HttpResult<bool>.NotFound("Listing not found");

        var user = await _userRepository.GetUserByIdAsync(userId);
        if(user == null)
            return HttpResult<bool>.Forbidden("User not found");
        
        if(listing.CurrentTicketCount == listing.MaxTicketCount)
            return HttpResult<bool>.BadRequest("Max ticket count reached");

        var ticket = new Ticket()
        {
            User = user,
            Listing = listing,
        };
        
        var success = await _ticketRepository.AddTicketAsync(ticket);

        return HttpResult<bool>.Ok(success);
    }
}