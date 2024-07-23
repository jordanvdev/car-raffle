namespace car_raffle_model;

public class Ticket
{
    public Guid Id { get; set; }
    public virtual User User { get; set; }
    public virtual Listing Listing { get; set; }
    public int Price { get; set; }
}