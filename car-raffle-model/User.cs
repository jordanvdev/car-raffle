namespace car_raffle_model;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public virtual List<Listing> Listings { get; set; }
}