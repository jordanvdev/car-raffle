using System.Text.Json.Serialization;
using car_raffle_ticket_data.EF_Models;

namespace car_raffle_ticket_data.Response_Models;

public class TicketResponse
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    [JsonPropertyName("userId")]
    public Guid UserId { get; set; }
    [JsonPropertyName("listingId")]
    public Guid ListingId { get; set; }
    
    public TicketResponse(Ticket ticket)
    {
        Id = ticket.Id;
        UserId = ticket.UserId;
        ListingId = ticket.ListingId;
    }
}