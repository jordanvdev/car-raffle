namespace car_raffle_listing_data.EF_Models;

public class Ticket
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ListingId { get; set; }

    public Ticket()
    {
        
    }
}