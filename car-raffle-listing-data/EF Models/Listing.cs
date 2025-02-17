namespace car_raffle_listing_data.EF_Models;

public class Listing
{
    public Guid Id { get; set; }
    public Guid CarId { get; set; }
    public Guid UserId { get; set; }
    public int MaxTicketCount { get; set; }
    public int CurrentTicketCount { get; set; }
    public double TicketPrice { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsApproved { get; set; }

    public Listing()
    {
        
    }
}