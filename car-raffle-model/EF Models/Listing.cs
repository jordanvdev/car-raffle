using car_raffle_model.API_Models;

namespace car_raffle_model;

public class Listing
{
    public Guid Id { get; set; }
    public Car Car { get; set; }
    public Guid CarId { get; set; }
    public User User { get; set; }
    public int MaxTicketCount { get; set; }
    public int CurrentTicketCount { get; set; }
    public List<Ticket> Tickets { get; set; }
    public double TicketPrice { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsApproved { get; set; }

    public Listing()
    {
        
    }

    public Listing(Car car, User user, ListingRequest listing)
    {
        Car = car;
        User = user;
        CreatedAt = listing.CreatedAt;
        EndDate = listing.EndDate;
        IsApproved = false;
        Tickets = new List<Ticket>();
    }
}