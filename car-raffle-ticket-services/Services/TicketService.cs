using car_raffle_model.Endpoint_Response;
using car_raffle_ticket_data.Repository;
using car_raffle_ticket_data.Response_Models;
using car_raffle_ticket_services.Services.Interfaces;

namespace car_raffle_ticket_services.Services;

public class TicketService : ITicketService
{
    private readonly ITicketRepository _ticketRepository;
    
    public TicketService(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }
    
    public async Task<HttpResult<bool>> AddTicketAsync(Guid listingId, Guid userId)
    {
        // var listing = await _listingRepository.GetListingById(listingId);
        // if (listing == null)
        //     return HttpResult<bool>.NotFound("Listing not found");
        //
        // var user = await _userRepository.GetUserByIdAsync(userId);
        // if(user == null)
        //     return HttpResult<bool>.Forbidden("User not found");
        //
        // if(listing.CurrentTicketCount == listing.MaxTicketCount)
        //     return HttpResult<bool>.BadRequest("Max ticket count reached");
        //
        // var ticket = new Ticket()
        // {
        //     User = user,
        //     Listing = listing,
        // };
        //
        // var success = await _ticketRepository.AddTicketAsync(ticket);

        return HttpResult<bool>.Ok(true);
    }

    public async Task<HttpResult<List<TicketResponse>>> GetTicketsByListingIdAsync(Guid listingId)
    {
        var tickets = await _ticketRepository.GetAllTicketsByListingIdAsync(listingId);

        if (tickets.Count == 0)
            return HttpResult<List<TicketResponse>>.NotFound("No tickets found");

        var responses = tickets.Select(a => new TicketResponse(a)).ToList();
        
        return HttpResult<List<TicketResponse>>.Ok(responses);
    }
}