namespace car_raffle_model;

public class Listing
{
    public Guid Id { get; set; }
    public virtual Car Car { get; set; }
    public Guid CarId { get; set; }
    public virtual User User { get; set; }
    public int MaxTicketCount { get; set; }
    public int CurrentTicketCount { get; set; }
    public virtual List<Ticket> Tickets { get; set; }
    public int TicketPrice { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime EndDate { get; set; }
}