using car_raffle_model.Endpoint_Response;
using car_raffle_ticket_data.EF_Models;
using car_raffle_ticket_data.Repository;
using car_raffle_ticket_data.Response_Models;
using car_raffle_ticket_services.Services.Interfaces;

namespace car_raffle_ticket_services.Services;

public class TicketService : ITicketService
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IListingHttpService _listingHttpService;
    private readonly IUserHttpService _userHttpService;

    public TicketService(ITicketRepository ticketRepository, IListingHttpService listingHttpService, IUserHttpService userHttpService)
    {
        _ticketRepository = ticketRepository;
        _listingHttpService = listingHttpService;
        _userHttpService = userHttpService;
    }
    
    public async Task<HttpResult<bool>> AddTicketAsync(Guid listingId, Guid userId)
    {
        var listing = await _listingHttpService.GetListingByIdAsync(listingId);
        if (listing == null)
            return HttpResult<bool>.NotFound("Listing not found");
        
        var user = await _userHttpService.GetUserByIdAsync(userId);
        if(user == null)
            return HttpResult<bool>.Forbidden("User not found");
        
        if(listing.CurrentTicketCount == listing.MaxTicketCount)
            return HttpResult<bool>.BadRequest("Max ticket count reached");
        
        var ticket = new Ticket()
        {
            UserId = user.Id,
            ListingId = listing.Id,
        };
        
        var success = await _ticketRepository.AddTicketAsync(ticket);

        return success ? HttpResult<bool>.Ok(success) : HttpResult<bool>.BadRequest("Failed to create ticket"); 
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