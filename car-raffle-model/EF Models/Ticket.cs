namespace car_raffle_model;

public class Ticket
{
    public Guid Id { get; set; }
    public User User { get; set; }
    public Listing Listing { get; set; }
}